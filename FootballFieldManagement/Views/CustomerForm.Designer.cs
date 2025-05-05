namespace FootballFieldManagement
{
    partial class CustomerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerForm));
            bindingSourceField = new BindingSource(components);
            dgvCustomers = new DataGridView();
            lblTitle = new Label();
            panelDataGrid = new Panel();
            panelControll = new Panel();
            panelSearch = new Panel();
            picSearchIcon = new PictureBox();
            txtSearch = new TextBox();
            btnImport = new Button();
            btnExport = new Button();
            btnAdd = new Button();
            panelTitle = new Panel();
            ((System.ComponentModel.ISupportInitialize)bindingSourceField).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            panelDataGrid.SuspendLayout();
            panelControll.SuspendLayout();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSearchIcon).BeginInit();
            panelTitle.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCustomers
            // 
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Dock = DockStyle.Fill;
            dgvCustomers.Location = new Point(0, 0);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.Size = new Size(942, 643);
            dgvCustomers.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.Location = new Point(3, 7);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(261, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ KHÁCH HÀNG";
            // 
            // panelDataGrid
            // 
            panelDataGrid.AutoScroll = true;
            panelDataGrid.Controls.Add(dgvCustomers);
            panelDataGrid.Dock = DockStyle.Fill;
            panelDataGrid.Location = new Point(0, 110);
            panelDataGrid.Name = "panelDataGrid";
            panelDataGrid.Size = new Size(942, 643);
            panelDataGrid.TabIndex = 6;
            // 
            // panelControll
            // 
            panelControll.Controls.Add(panelSearch);
            panelControll.Controls.Add(btnImport);
            panelControll.Controls.Add(btnExport);
            panelControll.Controls.Add(btnAdd);
            panelControll.Dock = DockStyle.Top;
            panelControll.Location = new Point(0, 40);
            panelControll.Name = "panelControll";
            panelControll.Padding = new Padding(0, 0, 0, 4);
            panelControll.Size = new Size(942, 70);
            panelControll.TabIndex = 5;
            // 
            // panelSearch
            // 
            panelSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelSearch.BackColor = Color.White;
            panelSearch.BorderStyle = BorderStyle.Fixed3D;
            panelSearch.Controls.Add(picSearchIcon);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Location = new Point(12, 9);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(361, 40);
            panelSearch.TabIndex = 0;
            // 
            // picSearchIcon
            // 
            picSearchIcon.Image = Properties.Resources.search;
            picSearchIcon.Location = new Point(3, 5);
            picSearchIcon.Name = "picSearchIcon";
            picSearchIcon.Size = new Size(27, 27);
            picSearchIcon.SizeMode = PictureBoxSizeMode.Zoom;
            picSearchIcon.TabIndex = 0;
            picSearchIcon.TabStop = false;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(36, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(305, 27);
            txtSearch.TabIndex = 1;
            // 
            // btnImport
            // 
            btnImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnImport.Location = new Point(518, 9);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(100, 40);
            btnImport.TabIndex = 2;
            btnImport.Text = "Nhập";
            btnImport.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExport.Location = new Point(624, 9);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(100, 40);
            btnExport.TabIndex = 3;
            btnExport.Text = "Xuất";
            btnExport.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BackColor = Color.FromArgb(64, 192, 255);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
            btnAdd.Location = new Point(730, 9);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(200, 40);
            btnAdd.TabIndex = 4;
            btnAdd.Text = " Thêm mới";
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // panelTitle
            // 
            panelTitle.Controls.Add(lblTitle);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(0, 0);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(942, 40);
            panelTitle.TabIndex = 4;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 753);
            Controls.Add(panelDataGrid);
            Controls.Add(panelControll);
            Controls.Add(panelTitle);
            Name = "CustomerForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)bindingSourceField).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            panelDataGrid.ResumeLayout(false);
            panelControll.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSearchIcon).EndInit();
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private BindingSource bindingSourceField;
        private DataGridView dgvCustomers;
        private Label lblTitle;
        private Panel panelDataGrid;
        private Panel panelControll;
        private Panel panelSearch;
        private PictureBox picSearchIcon;
        private TextBox txtSearch;
        private Button btnImport;
        private Button btnExport;
        private Button btnAdd;
        private Panel panelTitle;
    }
}
