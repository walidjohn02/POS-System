using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace theGrandCouchApp
{
    partial class DebtForm
    {
        private DataGridView dataGridView1;
        private Button btnMarkPaid;
        private Button btnBack;
        private Label lblTitle;

        private void InitializeComponent()
        {
            // =========================
            // FORM SETTINGS
            // =========================
            this.ClientSize = new Size(1366, 768);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Debt Manager";

            // =========================
            // TITLE LABEL
            // =========================
            lblTitle = new Label()
            {
                Text = "DEBT MANAGEMENT",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 100
            };

            // =========================
            // DATAGRIDVIEW
            // =========================
            dataGridView1 = new DataGridView()
            {
                Location = new Point(50, 150),
                Size = new Size(1266, 450),
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.FromArgb(45, 45, 45),
                BorderStyle = BorderStyle.None,
                EnableHeadersVisualStyles = false,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(0, 102, 204),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold)
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(60, 60, 60),
                    ForeColor = Color.White,
                    SelectionBackColor = Color.FromArgb(0, 102, 204),
                    SelectionForeColor = Color.White
                }
            };

            // =========================
            // BUTTONS
            // =========================
            Font buttonFont = new Font("Segoe UI", 14F, FontStyle.Bold);
            Color buttonBlue = Color.FromArgb(0, 102, 204);

            void StyleButton(Button btn)
            {
                btn.Font = buttonFont;
                btn.BackColor = buttonBlue;
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = ControlPaint.Light(buttonBlue);
                btn.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(buttonBlue);
                btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 20, 20));
            }

            // Place buttons at bottom corners
            btnMarkPaid = new Button()
            {
                Text = "Mark As Paid",
                Size = new Size(200, 50),
                Location = new Point(50, 650)
            };

            btnBack = new Button()
            {
                Text = "Back",
                Size = new Size(150, 50),
                Location = new Point(1166, 650)
            };

            StyleButton(btnMarkPaid);
            StyleButton(btnBack);

            // =========================
            // ADD CONTROLS
            // =========================
            Controls.Add(lblTitle);
            Controls.Add(dataGridView1);
            Controls.Add(btnMarkPaid);
            Controls.Add(btnBack);
        }

        // =========================
        // ROUNDED BUTTONS
        // =========================
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse);

        private DataGridView dgvProducts;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnLoad;
        private Button btnExit;
        private Label lblId;
        private Label lblBarcode;
        private Label lblName;
        private Label lblPrice;
        private Label lblQuantity;
        private Label lblPurchasePrice;
        private TextBox txtId;
        private TextBox txtBarcode;
        private TextBox txtName;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private TextBox txtPurchasePrice;
    }
}