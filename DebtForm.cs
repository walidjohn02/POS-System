using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Windows.Forms;

namespace theGrandCouchApp
{
    public partial class DebtForm : Form
    {
        private string connectionString = "Data Source=inventory.db";
        private HomeForm _homeForm;

        public DebtForm(HomeForm homeForm)
        {
            InitializeComponent();
            _homeForm = homeForm;

            btnMarkPaid.Click += BtnMarkPaid_Click;
            btnBack.Click += BtnBack_Click;

            LoadDebts();
        }

        private void LoadDebts()
        {
            using var conn = new SqliteConnection(connectionString);
            conn.Open();

            string query = @"
                SELECT Id, SaleDate, Total
                FROM Sales
                WHERE IsDebt = 1";

            using var cmd = new SqliteCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            dataGridView1.DataSource = dt;
        }

        private void BtnMarkPaid_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;

            int saleId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

            using var conn = new SqliteConnection(connectionString);
            conn.Open();

            string update = "UPDATE Sales SET IsDebt = 0 WHERE Id = @id";
            using var cmd = new SqliteCommand(update, conn);
            cmd.Parameters.AddWithValue("@id", saleId);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Sale marked as PAID ✅");

            LoadDebts(); // refresh the DataGridView

            // Refresh ReportForm if it's open
            foreach (Form f in Application.OpenForms)
            {
                if (f is ReportForm report)
                {
                    report.RefreshReport();
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _homeForm.Show();
            base.OnFormClosed(e);
        }
    }
}