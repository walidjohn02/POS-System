using Microsoft.Data.Sqlite;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace theGrandCouchApp
{
    public partial class ReportForm : Form
    {
        private string connectionString = "Data Source=inventory.db";
        private HomeForm _homeForm;

        public ReportForm(HomeForm homeForm)
        {
            InitializeComponent();
            _homeForm = homeForm;

            btnBack.Click += BtnBack_Click;

            LoadReport();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _homeForm.Show();
            base.OnFormClosed(e);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadReport()
        {
            var us = new CultureInfo("en-US");

            // TODAY
            lblTodaySales.Text = "Sales: " +
                GetSales("date(SaleDate) = date('now')").ToString("C", us);

            lblTodayProfit.Text = "Profit: " +
                GetProfit("date(SaleDate) = date('now')").ToString("C", us);

            lblTodayDebt.Text = "Debt: " +
                GetDebt("date(SaleDate) = date('now')").ToString("C", us);

            // WEEK
            lblWeekSales.Text = "Sales: " +
                GetSales("strftime('%W', SaleDate) = strftime('%W', 'now')").ToString("C", us);

            lblWeekProfit.Text = "Profit: " +
                GetProfit("strftime('%W', SaleDate) = strftime('%W', 'now')").ToString("C", us);

            lblWeekDebt.Text = "Debt: " +
                GetDebt("strftime('%W', SaleDate) = strftime('%W', 'now')").ToString("C", us);

            // MONTH
            lblMonthSales.Text = "Sales: " +
                GetSales("strftime('%m', SaleDate) = strftime('%m', 'now')").ToString("C", us);

            lblMonthProfit.Text = "Profit: " +
                GetProfit("strftime('%m', SaleDate) = strftime('%m', 'now')").ToString("C", us);

            lblMonthDebt.Text = "Debt: " +
                GetDebt("strftime('%m', SaleDate) = strftime('%m', 'now')").ToString("C", us);

            // YEAR
            lblYearSales.Text = "Sales: " +
                GetSales("strftime('%Y', SaleDate) = strftime('%Y', 'now')").ToString("C", us);

            lblYearProfit.Text = "Profit: " +
                GetProfit("strftime('%Y', SaleDate) = strftime('%Y', 'now')").ToString("C", us);

            lblYearDebt.Text = "Debt: " +
                GetDebt("strftime('%Y', SaleDate) = strftime('%Y', 'now')").ToString("C", us);
        }

        private decimal GetSales(string condition)
        {
            using var conn = new SqliteConnection(connectionString);
            conn.Open();

            string query = $@"
                SELECT IFNULL(SUM(Total), 0)
                FROM Sales
                WHERE {condition}";

            using var cmd = new SqliteCommand(query, conn);
            return Convert.ToDecimal(cmd.ExecuteScalar());
        }

        private decimal GetDebt(string condition)
        {
            using var conn = new SqliteConnection(connectionString);
            conn.Open();

            string query = $@"
                SELECT IFNULL(SUM(Total), 0)
                FROM Sales
                WHERE {condition} AND IsDebt = 1";

            using var cmd = new SqliteCommand(query, conn);
            return Convert.ToDecimal(cmd.ExecuteScalar());
        }

        public void RefreshReport()
        {
            LoadReport(); // reloads all sales, profit, debt labels
        }

        private decimal GetProfit(string condition)
        {
            using var conn = new SqliteConnection(connectionString);
            conn.Open();

            string query = $@"
                SELECT IFNULL(SUM((SI.Price - P.PurchasePrice) * SI.Quantity), 0)
                FROM SaleItems SI
                JOIN Sales S ON SI.SaleId = S.Id
                JOIN Products P ON SI.ProductId = P.Id
                WHERE {condition}";

            using var cmd = new SqliteCommand(query, conn);
            return Convert.ToDecimal(cmd.ExecuteScalar());
        }
    }
}