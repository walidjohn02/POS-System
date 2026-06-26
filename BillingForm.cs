using System;
using System.Data;
using Microsoft.Data.Sqlite;
using System.Windows.Forms;

namespace theGrandCouchApp
{
    public partial class BillingForm : Form
    {
        private Form _homeForm;
        private double currentTotal = 0;
        private string connectionString = Program.ConnectionString;

        public BillingForm(Form homeForm)
        {
            InitializeComponent();
            _homeForm = homeForm;

            txtBillQuantity.Text = "1";

            txtSearch.KeyDown += TxtSearch_KeyDown;
            btnAddToBill.Click += BtnAddToBill_Click;
            btnCheckout.Click += BtnCheckout_Click;
            btnDebt.Click += BtnDebt_Click;
            btnRemoveItem.Click += BtnRemoveItem_Click;
            btnClearBill.Click += BtnClearBill_Click;
            btnExit.Click += BtnExit_Click;

            SetupGrid();
        }

        private void SetupGrid()
        {
            dgvBill.Columns.Clear();

            // Hidden ProductId column
            var colId = new DataGridViewTextBoxColumn
            {
                Name = "ProductId",
                HeaderText = "ProductId",
                Visible = false
            };
            dgvBill.Columns.Add(colId);

            dgvBill.Columns.Add("Name", "Product");
            dgvBill.Columns.Add("Price", "Price");
            dgvBill.Columns.Add("Qty", "Qty");
            dgvBill.Columns.Add("Total", "Total");
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AddItemToBill();
        }

        private void BtnAddToBill_Click(object sender, EventArgs e) => AddItemToBill();

        private void AddItemToBill()
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text)) return;

            int qty = int.TryParse(txtBillQuantity.Text, out int q) ? q : 1;

            using var conn = new SqliteConnection(connectionString);
            conn.Open();

            var cmd = new SqliteCommand(
                "SELECT Id, Name, Price FROM Products WHERE Name=@name OR Barcode=@name", conn);
            cmd.Parameters.AddWithValue("@name", txtSearch.Text);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                int productId = Convert.ToInt32(reader["Id"]);
                string name = reader["Name"].ToString();
                double price = Convert.ToDouble(reader["Price"]);
                double total = price * qty;

                dgvBill.Rows.Add(productId, name, price, qty, total);

                currentTotal += total;
                lblTotal.Text = currentTotal.ToString("0.00");
            }
            else
            {
                MessageBox.Show("Product not found.");
            }

            txtSearch.Clear();
            txtBillQuantity.Text = "1";
            txtSearch.Focus();
        }

        private void BtnCheckout_Click(object sender, EventArgs e) => SaveSale(false);
        private void BtnDebt_Click(object sender, EventArgs e) => SaveSale(true);

        private void SaveSale(bool isDebt)
        {
            if (dgvBill.Rows.Count == 0) return;

            using var conn = new SqliteConnection(connectionString);
            conn.Open();

            using var transaction = conn.BeginTransaction();

            try
            {
                // 1️⃣ Check stock for each item first
                foreach (DataGridViewRow row in dgvBill.Rows)
                {
                    if (row.Cells["Qty"].Value == null) continue;

                    int productId = Convert.ToInt32(row.Cells["ProductId"].Value);
                    int qtyRequested = Convert.ToInt32(row.Cells["Qty"].Value);

                    var cmdCheck = new SqliteCommand(
                        "SELECT Quantity FROM Products WHERE Id = @id;",
                        conn,
                        transaction);

                    cmdCheck.Parameters.AddWithValue("@id", productId);
                    int availableQty = Convert.ToInt32(cmdCheck.ExecuteScalar() ?? 0);

                    if (qtyRequested > availableQty)
                    {
                        MessageBox.Show($"Not enough stock for {row.Cells["Name"].Value}. Available: {availableQty}");
                        transaction.Rollback();
                        return;
                    }
                }

                // 2️⃣ Calculate total
                double totalAmount = 0;
                foreach (DataGridViewRow row in dgvBill.Rows)
                {
                    if (row.Cells["Qty"].Value != null)
                        totalAmount += Convert.ToDouble(row.Cells["Price"].Value) *
                                       Convert.ToInt32(row.Cells["Qty"].Value);
                }

                // 3️⃣ Insert into Sales
                var cmdSale = new SqliteCommand(
                    "INSERT INTO Sales (Total, SaleDate, IsDebt) VALUES (@total,@date,@isDebt);",
                    conn,
                    transaction);

                cmdSale.Parameters.AddWithValue("@total", totalAmount);
                cmdSale.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmdSale.Parameters.AddWithValue("@isDebt", isDebt ? 1 : 0);
                cmdSale.ExecuteNonQuery();

                long saleId = (long)new SqliteCommand(
                    "SELECT last_insert_rowid();",
                    conn,
                    transaction)
                    .ExecuteScalar();

                // 4️⃣ Insert into SaleItems & Update Product Quantity
                foreach (DataGridViewRow row in dgvBill.Rows)
                {
                    if (row.Cells["Qty"].Value == null) continue;

                    int qtySold = Convert.ToInt32(row.Cells["Qty"].Value);
                    int productId = Convert.ToInt32(row.Cells["ProductId"].Value);

                    // Insert into SaleItems
                    var cmdItem = new SqliteCommand(
                        @"INSERT INTO SaleItems 
                  (SaleId, ProductId, ProductName, Quantity, Price)
                  VALUES (@saleId, @productId, @name, @qty, @price);",
                        conn,
                        transaction);

                    cmdItem.Parameters.AddWithValue("@saleId", saleId);
                    cmdItem.Parameters.AddWithValue("@productId", productId);
                    cmdItem.Parameters.AddWithValue("@name", row.Cells["Name"].Value);
                    cmdItem.Parameters.AddWithValue("@qty", qtySold);
                    cmdItem.Parameters.AddWithValue("@price", row.Cells["Price"].Value);
                    cmdItem.ExecuteNonQuery();

                    // Update stock
                    var cmdUpdateStock = new SqliteCommand(
                        "UPDATE Products SET Quantity = Quantity - @soldQty WHERE Id = @productId;",
                        conn,
                        transaction);

                    cmdUpdateStock.Parameters.AddWithValue("@soldQty", qtySold);
                    cmdUpdateStock.Parameters.AddWithValue("@productId", productId);
                    cmdUpdateStock.ExecuteNonQuery();
                }

                transaction.Commit();

                MessageBox.Show(isDebt ? "Saved as Debt!" : "Checkout Completed!");
                dgvBill.Rows.Clear();
                currentTotal = 0;
                lblTotal.Text = "0.00";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Error saving sale: " + ex.Message);
            }
        }

        private void BtnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvBill.SelectedRows.Count > 0)
            {
                double rowTotal = Convert.ToDouble(dgvBill.SelectedRows[0].Cells["Total"].Value);
                currentTotal -= rowTotal;
                dgvBill.Rows.RemoveAt(dgvBill.SelectedRows[0].Index);
                lblTotal.Text = currentTotal.ToString("0.00");
            }
        }

        private void BtnClearBill_Click(object sender, EventArgs e)
        {
            dgvBill.Rows.Clear();
            currentTotal = 0;
            lblTotal.Text = "0.00";
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            _homeForm.Show();
        }
    }
}