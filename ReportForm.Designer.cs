using System.Drawing;
using System.Windows.Forms;

namespace theGrandCouchApp
{
    partial class ReportForm
    {
        private Label lblTodayTitle;
        private Label lblTodaySales;
        private Label lblTodayProfit;
        private Label lblTodayDebt;

        private Label lblWeekTitle;
        private Label lblWeekSales;
        private Label lblWeekProfit;
        private Label lblWeekDebt;

        private Label lblMonthTitle;
        private Label lblMonthSales;
        private Label lblMonthProfit;
        private Label lblMonthDebt;

        private Label lblYearTitle;
        private Label lblYearSales;
        private Label lblYearProfit;
        private Label lblYearDebt;

        private Button btnBack;

        

        private void InitializeComponent()
        {
            // =========================
            // FORM SETTINGS
            // =========================
            this.Text = "Reports";
            this.ClientSize = new Size(1366, 768); // lock to 1366x768
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            Font titleFont = new Font("Segoe UI", 16, FontStyle.Bold);
            Font valueFont = new Font("Segoe UI", 14, FontStyle.Regular);

            int startX = 50;
            int sectionSpacingY = 180;
            int labelSpacing = 30;

            // ===== TODAY =====
            lblTodayTitle = new Label()
            {
                Text = "TODAY",
                ForeColor = Color.White,
                Font = titleFont,
                Location = new Point(startX, 30),
                AutoSize = true
            };
            lblTodaySales = CreateValueLabel(startX, 70, valueFont);
            lblTodayProfit = CreateValueLabel(startX, 100, valueFont);
            lblTodayDebt = CreateValueLabel(startX, 130, valueFont, Color.Red);

            // ===== WEEK =====
            lblWeekTitle = new Label()
            {
                Text = "THIS WEEK",
                ForeColor = Color.White,
                Font = titleFont,
                Location = new Point(startX, 30 + sectionSpacingY),
                AutoSize = true
            };
            lblWeekSales = CreateValueLabel(startX, 70 + sectionSpacingY, valueFont);
            lblWeekProfit = CreateValueLabel(startX, 100 + sectionSpacingY, valueFont);
            lblWeekDebt = CreateValueLabel(startX, 130 + sectionSpacingY, valueFont, Color.Red);

            // ===== MONTH =====
            lblMonthTitle = new Label()
            {
                Text = "THIS MONTH",
                ForeColor = Color.White,
                Font = titleFont,
                Location = new Point(startX, 30 + sectionSpacingY * 2),
                AutoSize = true
            };
            lblMonthSales = CreateValueLabel(startX, 70 + sectionSpacingY * 2, valueFont);
            lblMonthProfit = CreateValueLabel(startX, 100 + sectionSpacingY * 2, valueFont);
            lblMonthDebt = CreateValueLabel(startX, 130 + sectionSpacingY * 2, valueFont, Color.Red);

            // ===== YEAR =====
            lblYearTitle = new Label()
            {
                Text = "THIS YEAR",
                ForeColor = Color.White,
                Font = titleFont,
                Location = new Point(startX, 30 + sectionSpacingY * 3),
                AutoSize = true
            };
            lblYearSales = CreateValueLabel(startX, 70 + sectionSpacingY * 3, valueFont);
            lblYearProfit = CreateValueLabel(startX, 100 + sectionSpacingY * 3, valueFont);
            lblYearDebt = CreateValueLabel(startX, 130 + sectionSpacingY * 3, valueFont, Color.Red);

            // ===== BACK BUTTON =====
            btnBack = new Button()
            {
                Text = "Back",
                Size = new Size(120, 50),
                Location = new Point(1366 - 150, 768 - 80), // bottom-right
                BackColor = Color.Black,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnBack.FlatAppearance.BorderSize = 0;

            // ADD CONTROLS
            this.Controls.AddRange(new Control[]
            {
                lblTodayTitle, lblTodaySales, lblTodayProfit, lblTodayDebt,
                lblWeekTitle, lblWeekSales, lblWeekProfit, lblWeekDebt,
                lblMonthTitle, lblMonthSales, lblMonthProfit, lblMonthDebt,
                lblYearTitle, lblYearSales, lblYearProfit, lblYearDebt,
                btnBack
            });
        }

        private Label CreateValueLabel(int x, int y, Font font, Color? color = null)
        {
            return new Label()
            {
                Location = new Point(x, y),
                ForeColor = color ?? Color.White,
                Font = font,
                AutoSize = true
            };
        }

        
    }
}