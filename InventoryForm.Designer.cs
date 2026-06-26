namespace theGrandCouchApp
{
    partial class InventoryForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvProducts = new DataGridView();
            txtId = new TextBox();
            txtBarcode = new TextBox();
            txtName = new TextBox();
            txtPrice = new TextBox();
            txtQuantity = new TextBox();
            txtPurchasePrice = new TextBox();

            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnLoad = new Button();
            btnExit = new Button();

            lblId = new Label();
            lblBarcode = new Label();
            lblName = new Label();
            lblPrice = new Label();
            lblQuantity = new Label();
            lblPurchasePrice = new Label();

            Panel headerPanel = new Panel();
            Label lblTitle = new Label();

            SuspendLayout();

            // FORM
            this.Text = "Inventory";
            this.ClientSize = new Size(1366, 768);
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;

            // HEADER PANEL
            headerPanel.Location = new Point(0, 0);
            headerPanel.Size = new Size(1366, 80);
            headerPanel.BackColor = Color.FromArgb(45, 45, 45);

            // TITLE
            lblTitle.Text = "Inventory Management";
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.AutoSize = true;
            headerPanel.Controls.Add(lblTitle);

            // EXIT BUTTON
            btnExit.Text = "Exit";
            btnExit.Size = new Size(120, 40);
            btnExit.BackColor = Color.FromArgb(0, 102, 204);
            btnExit.ForeColor = Color.White;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.Location = new Point(1246, 20); // 1366 - 120 - margin
            headerPanel.Controls.Add(btnExit);

            // DATAGRID
            dgvProducts.Location = new Point(40, 100);
            dgvProducts.Size = new Size(1286, 400); // 1366 - margins
            dgvProducts.BackgroundColor = Color.FromArgb(45, 45, 45);
            dgvProducts.DefaultCellStyle.ForeColor = Color.White;
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // LABELS & TEXTBOXES
            int startX = 40;
            int startY = 540;
            int spacingX = 210;
            int labelOffsetY = -25;
            int textboxWidth = 180;
            int textboxHeight = 35;

            SetupLabel(lblId, "ID:", startX, startY + labelOffsetY);
            SetupLabel(lblBarcode, "Barcode:", startX + spacingX, startY + labelOffsetY);
            SetupLabel(lblName, "Name:", startX + spacingX * 2, startY + labelOffsetY);
            SetupLabel(lblPrice, "Price:", startX + spacingX * 3, startY + labelOffsetY);
            SetupLabel(lblQuantity, "Quantity:", startX + spacingX * 4, startY + labelOffsetY);
            SetupLabel(lblPurchasePrice, "Purchase Price:", startX + spacingX * 5, startY + labelOffsetY);

            txtId.Location = new Point(startX, startY);
            txtBarcode.Location = new Point(startX + spacingX, startY);
            txtName.Location = new Point(startX + spacingX * 2, startY);
            txtPrice.Location = new Point(startX + spacingX * 3, startY);
            txtQuantity.Location = new Point(startX + spacingX * 4, startY);
            txtPurchasePrice.Location = new Point(startX + spacingX * 5, startY);

            txtId.Size = txtBarcode.Size = txtName.Size = txtPrice.Size = txtQuantity.Size = txtPurchasePrice.Size =
                new Size(textboxWidth, textboxHeight);

            // BUTTONS
            int btnStartX = startX;
            int btnStartY = startY + 60;
            int btnSpacing = 140;

            btnAdd.Text = "Add";
            btnUpdate.Text = "Update";
            btnDelete.Text = "Delete";
            btnLoad.Text = "Load";

            btnAdd.Location = new Point(btnStartX, btnStartY);
            btnUpdate.Location = new Point(btnStartX + btnSpacing, btnStartY);
            btnDelete.Location = new Point(btnStartX + btnSpacing * 2, btnStartY);
            btnLoad.Location = new Point(btnStartX + btnSpacing * 3, btnStartY);

            void StyleBlue(Button btn)
            {
                btn.Size = new Size(120, 40);
                btn.BackColor = Color.FromArgb(0, 102, 204);
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }

            StyleBlue(btnAdd);
            StyleBlue(btnUpdate);
            StyleBlue(btnDelete);
            StyleBlue(btnLoad);

            // ADD CONTROLS
            Controls.Add(headerPanel);
            Controls.Add(dgvProducts);

            Controls.Add(lblId);
            Controls.Add(lblBarcode);
            Controls.Add(lblName);
            Controls.Add(lblPrice);
            Controls.Add(lblQuantity);
            Controls.Add(lblPurchasePrice);

            Controls.Add(txtId);
            Controls.Add(txtBarcode);
            Controls.Add(txtName);
            Controls.Add(txtPrice);
            Controls.Add(txtQuantity);
            Controls.Add(txtPurchasePrice);

            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnLoad);

            ResumeLayout(false);
        }

        private void SetupLabel(Label lbl, string text, int x, int y)
        {
            lbl.Text = text;
            lbl.ForeColor = Color.White;
            lbl.Location = new Point(x, y);
            lbl.AutoSize = true;
        }

        private DataGridView dgvProducts;
        private TextBox txtId;
        private TextBox txtBarcode;
        private TextBox txtName;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private TextBox txtPurchasePrice;

        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnLoad;
        private Button btnExit;

        private Label lblPurchasePrice;
        private Label lblId;
        private Label lblBarcode;
        private Label lblName;
        private Label lblPrice;
        private Label lblQuantity;
    }
}