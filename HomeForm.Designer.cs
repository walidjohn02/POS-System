using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace theGrandCouchApp
{
    partial class HomeForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            btnInventory = new Button();
            btnBilling = new Button();
            btnReports = new Button();
            btnDebt = new Button(); // NEW
            btnExit = new Button();

            SuspendLayout();

            // =========================
            // FORM SETTINGS
            // =========================
            this.ClientSize = new Size(1366, 768); // fixed size
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Grand Couch POS";

            // =========================
            // TITLE LABEL
            // =========================
            label1.Text = "GRAND COUCH POS SYSTEM";
            label1.ForeColor = Color.White;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            label1.AutoSize = false;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Dock = DockStyle.Top;
            label1.Height = 180;

            // =========================
            // BUTTON STYLE SETTINGS
            // =========================
            Font buttonFont = new Font("Segoe UI", 16F, FontStyle.Bold);
            int btnWidth = 300;
            int btnHeight = 80;
            int spacingY = 30;
            Color buttonBlue = Color.FromArgb(0, 102, 204);

            void StyleButton(Button btn)
            {
                btn.Font = buttonFont;
                btn.Size = new Size(btnWidth, btnHeight);
                btn.BackColor = buttonBlue;
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = ControlPaint.Light(buttonBlue);
                btn.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(buttonBlue);
                btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 20, 20));
            }

            StyleButton(btnInventory);
            StyleButton(btnBilling);
            StyleButton(btnReports);
            StyleButton(btnDebt);
            StyleButton(btnExit);

            btnInventory.Text = "Manage Inventory";
            btnBilling.Text = "Billing / Sales";
            btnReports.Text = "Reports";
            btnDebt.Text = "Manage Debt";
            btnExit.Text = "Exit";

            // =========================
            // CENTER BUTTONS
            // =========================
            int totalButtonsHeight = btnHeight * 5 + spacingY * 4; // 5 buttons
            int startY = (768 - totalButtonsHeight) / 2 + 50;
            int centerX = (1366 - btnWidth) / 2;

            btnInventory.Location = new Point(centerX, startY);
            btnBilling.Location = new Point(centerX, startY + btnHeight + spacingY);
            btnReports.Location = new Point(centerX, startY + (btnHeight + spacingY) * 2);
            btnDebt.Location = new Point(centerX, startY + (btnHeight + spacingY) * 3);
            btnExit.Location = new Point(centerX, startY + (btnHeight + spacingY) * 4);

            // =========================
            // ADD CONTROLS
            // =========================
            Controls.Add(label1);
            Controls.Add(btnInventory);
            Controls.Add(btnBilling);
            Controls.Add(btnReports);
            Controls.Add(btnDebt);
            Controls.Add(btnExit);

            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button btnInventory;
        private Button btnBilling;
        private Button btnReports;
        private Button btnDebt;
        private Button btnExit;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse);
    }
}