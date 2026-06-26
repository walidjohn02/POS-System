using System;
using System.Windows.Forms;

namespace theGrandCouchApp
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();

            this.btnInventory.Click += btnInventory_Click;
            this.btnBilling.Click += btnBilling_Click;
            this.btnReports.Click += btnReports_Click;
            this.btnExit.Click += btnExit_Click;
            this.btnDebt.Click += btnDebt_Click;
        }

        // ----------------------------
        // INVENTORY BUTTON
        // ----------------------------
        private void btnInventory_Click(object sender, EventArgs e)
        {
            this.Hide();

            InventoryForm inventory = new InventoryForm(this);
            inventory.ShowDialog();

            this.Show();
        }

        // ----------------------------
        // BILLING BUTTON
        // ----------------------------
        private void btnBilling_Click(object sender, EventArgs e)
        {
            this.Hide();

            BillingForm billing = new BillingForm(this);
            billing.Show();
        }

        // ----------------------------
        // REPORTS BUTTON
        // ----------------------------
        private void btnReports_Click(object sender, EventArgs e)
        {
            this.Hide();

            ReportForm reports = new ReportForm(this);
            reports.Show();
        }

        // ----------------------------
        // DEBT BUTTON
        // ----------------------------
        private void btnDebt_Click(object sender, EventArgs e)
        {
            this.Hide();
            DebtForm debt = new DebtForm(this);
            debt.ShowDialog();
        }

        // ----------------------------
        // EXIT BUTTON
        // ----------------------------
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}