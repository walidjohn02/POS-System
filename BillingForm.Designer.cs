using System;
using System.Windows.Forms;
using System.Drawing;

namespace theGrandCouchApp
{
    partial class BillingForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtSearch;
        private TextBox txtBillQuantity;
        private Button btnAddToBill;
        private Button btnRemoveItem;
        private Button btnClearBill;
        private Button btnCheckout;
        private Button btnDebt;
        private Button btnExit;
        private DataGridView dgvBill;
        private Label lblTotal;
        private Label labelTotal;
        private Label labelSearch;
        private Label labelQuantity;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            SuspendLayout();

            // =========================
            // FORM SETTINGS
            // =========================
            this.ClientSize = new Size(1366, 768);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Billing Page";

            // =========================
            // Textboxes
            // =========================
            txtSearch = new TextBox()
            {
                Font = new Font("Segoe UI", 14F),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(45, 45, 45),
                BorderStyle = BorderStyle.None,
                Location = new Point(50, 20),
                Size = new Size(350, 35)
            };

            txtBillQuantity = new TextBox()
            {
                Font = new Font("Segoe UI", 14F),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(45, 45, 45),
                BorderStyle = BorderStyle.None,
                Location = new Point(420, 20),
                Size = new Size(60, 35)
            };

            // =========================
            // Buttons
            // =========================
            Color buttonBlue = Color.FromArgb(0, 102, 204);
            btnAddToBill = CreateButton("ADD", 500, 20, 120, 35, buttonBlue);
            btnRemoveItem = CreateButton("REMOVE", 50, 650, 120, 40, buttonBlue);
            btnClearBill = CreateButton("CLEAR", 190, 650, 120, 40, buttonBlue);
            btnCheckout = CreateButton("CHECKOUT", 330, 650, 200, 50, buttonBlue, 12F);
            btnDebt = CreateButton("SAVE AS DEBT", 550, 650, 160, 50, buttonBlue, 12F);
            btnExit = CreateButton("EXIT", 1266, 20, 80, 35, buttonBlue);

            // =========================
            // DataGridView
            // =========================
            dgvBill = new DataGridView()
            {
                AllowUserToAddRows = false,
                BackgroundColor = Color.FromArgb(40, 40, 40),
                ColumnHeadersHeight = 35,
                Location = new Point(50, 70),
                Size = new Size(1266, 550),
                RowTemplate = { Height = 32 },
                EnableHeadersVisualStyles = false,
                GridColor = Color.Gray
            };

            dgvBill.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = Color.FromArgb(60, 60, 60),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.White,
                SelectionBackColor = SystemColors.Highlight,
                SelectionForeColor = SystemColors.HighlightText,
                WrapMode = DataGridViewTriState.True
            };

            dgvBill.DefaultCellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = Color.FromArgb(45, 45, 45),
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.White,
                SelectionBackColor = SystemColors.Highlight,
                SelectionForeColor = SystemColors.HighlightText,
                WrapMode = DataGridViewTriState.False
            };

            // =========================
            // Labels
            // =========================
            lblTotal = new Label()
            {
                Font = new Font("Segoe UI", 26F, FontStyle.Bold),
                ForeColor = Color.Lime,
                BackColor = Color.FromArgb(30, 30, 30),
                TextAlign = ContentAlignment.MiddleRight,
                Location = new Point(1066, 650),
                Size = new Size(260, 60),
                Text = "0.00"
            };

            labelTotal = new Label()
            {
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(960, 660),
                Size = new Size(100, 40),
                Text = "TOTAL:"
            };

            labelSearch = new Label()
            {
                Font = new Font("Segoe UI", 12F),
                ForeColor = Color.White,
                Location = new Point(50, 0),
                Size = new Size(300, 23),
                Text = "Scan Barcode or Enter Name"
            };

            labelQuantity = new Label()
            {
                Font = new Font("Segoe UI", 12F),
                ForeColor = Color.White,
                Location = new Point(420, 0),
                Size = new Size(60, 23),
                Text = "Quantity"
            };

            // =========================
            // Add Controls
            // =========================
            Controls.Add(txtSearch);
            Controls.Add(txtBillQuantity);
            Controls.Add(btnAddToBill);
            Controls.Add(btnRemoveItem);
            Controls.Add(btnClearBill);
            Controls.Add(btnCheckout);
            Controls.Add(btnDebt);
            Controls.Add(btnExit);
            Controls.Add(dgvBill);
            Controls.Add(lblTotal);
            Controls.Add(labelTotal);
            Controls.Add(labelSearch);
            Controls.Add(labelQuantity);

            ResumeLayout(false);
            PerformLayout();
        }

        private Button CreateButton(string text, int x, int y, int width, int height, Color backColor, float fontSize = 11F)
        {
            var btn = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, height),
                BackColor = backColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", fontSize, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = ControlPaint.Light(backColor);
            btn.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(backColor);
            return btn;
        }
        #endregion
    }
}