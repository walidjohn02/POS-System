using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Windows.Forms;

namespace theGrandCouchApp
{
    public partial class InventoryForm : Form
    {
        private string connectionString = "Data Source=inventory.db";
        private Form _homeForm;

        public InventoryForm(Form homeForm)
        {
            InitializeComponent();

            _homeForm = homeForm;

            LoadProducts();

            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnLoad.Click += BtnLoad_Click;
            btnExit.Click += BtnExit_Click;

            dgvProducts.SelectionChanged += DgvProducts_SelectionChanged;
        }

        // ================= EXIT =================
        private void BtnExit_Click(object sender, EventArgs e)
        {
            _homeForm.Show();
            this.Close();
        }

        // ================= LOAD PRODUCTS =================
        private void LoadProducts()
        {
            using var conn = new SqliteConnection(connectionString);
            conn.Open();

            string query = "SELECT * FROM Products";
            using var cmd = new SqliteCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            dgvProducts.DataSource = dt;
        }

        // ================= ADD =================
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id) ||
                !double.TryParse(txtPrice.Text, out double price) ||
                !double.TryParse(txtPurchasePrice.Text, out double purchasePrice) ||
                !int.TryParse(txtQuantity.Text, out int quantity) ||
                string.IsNullOrWhiteSpace(txtBarcode.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter valid product data.");
                return;
            }

            using var conn = new SqliteConnection(connectionString);
            conn.Open();

            string query = @"INSERT INTO Products 
                    (Id, Barcode, Name, Price, PurchasePrice, Quantity) 
                    VALUES (@id, @barcode, @name, @price, @purchasePrice, @quantity)";

            using var cmd = new SqliteCommand(query, conn);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@purchasePrice", purchasePrice);
            cmd.Parameters.AddWithValue("@quantity", quantity);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }

            ClearInputs();
            LoadProducts();
        }

        // ================= UPDATE =================
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id) ||
                !double.TryParse(txtPrice.Text, out double price) ||
                !double.TryParse(txtPurchasePrice.Text, out double purchasePrice) ||
                !int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Invalid data.");
                return;
            }

            using var conn = new SqliteConnection(connectionString);
            conn.Open();

            string query = @"UPDATE Products 
                     SET Barcode=@barcode,
                         Name=@name,
                         Price=@price,
                         PurchasePrice=@purchasePrice,
                         Quantity=@quantity
                     WHERE Id=@id";

            using var cmd = new SqliteCommand(query, conn);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@purchasePrice", purchasePrice);
            cmd.Parameters.AddWithValue("@quantity", quantity);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Product updated successfully!");
            ClearInputs();
            LoadProducts();
        }

        // ================= DELETE =================
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Invalid ID.");
                return;
            }

            using var conn = new SqliteConnection(connectionString);
            conn.Open();

            string query = "DELETE FROM Products WHERE Id=@id";
            using var cmd = new SqliteCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Product deleted.");
            ClearInputs();
            LoadProducts();
        }

        // ================= LOAD BY ID =================
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Enter valid ID.");
                return;
            }

            using var conn = new SqliteConnection(connectionString);
            conn.Open();

            string query = "SELECT * FROM Products WHERE Id=@id";
            using var cmd = new SqliteCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                txtBarcode.Text = reader["Barcode"].ToString();
                txtName.Text = reader["Name"].ToString();
                txtPrice.Text = reader["Price"].ToString();
                txtPurchasePrice.Text = reader["PurchasePrice"].ToString();
                txtQuantity.Text = reader["Quantity"].ToString();
            }
            else
            {
                MessageBox.Show("Product not found.");
            }
        }

        private void ClearInputs()
        {
            txtId.Clear();
            txtBarcode.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtPurchasePrice.Clear();
            txtQuantity.Clear();
        }

        private void DgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null)
            {
                txtId.Text = dgvProducts.CurrentRow.Cells["Id"].Value?.ToString();
                txtBarcode.Text = dgvProducts.CurrentRow.Cells["Barcode"].Value?.ToString();
                txtName.Text = dgvProducts.CurrentRow.Cells["Name"].Value?.ToString();
                txtPrice.Text = dgvProducts.CurrentRow.Cells["Price"].Value?.ToString();
                txtPurchasePrice.Text = dgvProducts.CurrentRow.Cells["PurchasePrice"].Value?.ToString();
                txtQuantity.Text = dgvProducts.CurrentRow.Cells["Quantity"].Value?.ToString();
            }
        }
    }
}