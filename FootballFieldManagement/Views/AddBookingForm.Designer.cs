namespace FootballFieldManagement.Views
{
    partial class AddBookingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblCustomerName = new Label();
            cmbCustomerName = new ComboBox();
            lblFieldType = new Label();
            cmbFieldType = new ComboBox();
            lblFieldName = new Label();
            cmbFieldName = new ComboBox();
            lblBookingDate = new Label();
            dtpBookingDate = new DateTimePicker();
            lblHoursNumber = new Label();
            lblPricePerHour = new Label();
            lblTotal = new Label();
            lblUserCreated = new Label();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            panelHours = new TableLayoutPanel();
            lblCustomerPhone = new Label();
            txtCustomerPhone = new TextBox();
            lblShowUserCreated = new Label();
            lblShowHoursNumber = new Label();
            lblShowPricePerHour = new Label();
            lblShowTotal = new Label();
            lblDateCreated = new Label();
            lblShowDateCreated = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(420, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(100, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐẶT SÂN";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(11, 94);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(111, 20);
            lblCustomerName.TabIndex = 1;
            lblCustomerName.Text = "Tên khách hàng";
            // 
            // cmbCustomerName
            // 
            cmbCustomerName.FormattingEnabled = true;
            cmbCustomerName.Location = new Point(156, 91);
            cmbCustomerName.Name = "cmbCustomerName";
            cmbCustomerName.Size = new Size(265, 28);
            cmbCustomerName.TabIndex = 2;
            // 
            // lblFieldType
            // 
            lblFieldType.AutoSize = true;
            lblFieldType.Location = new Point(12, 170);
            lblFieldType.Name = "lblFieldType";
            lblFieldType.Size = new Size(63, 20);
            lblFieldType.TabIndex = 3;
            lblFieldType.Text = "Loại sân";
            // 
            // cmbFieldType
            // 
            cmbFieldType.FormattingEnabled = true;
            cmbFieldType.Location = new Point(156, 167);
            cmbFieldType.Name = "cmbFieldType";
            cmbFieldType.Size = new Size(265, 28);
            cmbFieldType.TabIndex = 4;
            // 
            // lblFieldName
            // 
            lblFieldName.AutoSize = true;
            lblFieldName.Location = new Point(520, 170);
            lblFieldName.Name = "lblFieldName";
            lblFieldName.Size = new Size(58, 20);
            lblFieldName.TabIndex = 5;
            lblFieldName.Text = "Tên sân";
            // 
            // cmbFieldName
            // 
            cmbFieldName.FormattingEnabled = true;
            cmbFieldName.Location = new Point(655, 167);
            cmbFieldName.Name = "cmbFieldName";
            cmbFieldName.Size = new Size(283, 28);
            cmbFieldName.TabIndex = 6;
            // 
            // lblBookingDate
            // 
            lblBookingDate.AutoSize = true;
            lblBookingDate.Location = new Point(12, 259);
            lblBookingDate.Name = "lblBookingDate";
            lblBookingDate.Size = new Size(70, 20);
            lblBookingDate.TabIndex = 7;
            lblBookingDate.Text = "Ngày đặt";
            // 
            // dtpBookingDate
            // 
            dtpBookingDate.Location = new Point(156, 254);
            dtpBookingDate.Name = "dtpBookingDate";
            dtpBookingDate.Size = new Size(265, 27);
            dtpBookingDate.TabIndex = 8;
            // 
            // lblHoursNumber
            // 
            lblHoursNumber.AutoSize = true;
            lblHoursNumber.Location = new Point(11, 538);
            lblHoursNumber.Name = "lblHoursNumber";
            lblHoursNumber.Size = new Size(59, 20);
            lblHoursNumber.TabIndex = 13;
            lblHoursNumber.Text = "Số giờ :";
            // 
            // lblPricePerHour
            // 
            lblPricePerHour.AutoSize = true;
            lblPricePerHour.Location = new Point(520, 538);
            lblPricePerHour.Name = "lblPricePerHour";
            lblPricePerHour.Size = new Size(90, 20);
            lblPricePerHour.TabIndex = 15;
            lblPricePerHour.Text = "Giá mỗi giờ:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(520, 605);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(83, 20);
            lblTotal.TabIndex = 17;
            lblTotal.Text = "Tổng cộng:";
            // 
            // lblUserCreated
            // 
            lblUserCreated.AutoSize = true;
            lblUserCreated.Location = new Point(12, 661);
            lblUserCreated.Name = "lblUserCreated";
            lblUserCreated.Size = new Size(110, 20);
            lblUserCreated.TabIndex = 19;
            lblUserCreated.Text = "Người tạo đơn:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(520, 259);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(75, 20);
            lblStatus.TabIndex = 20;
            lblStatus.Text = "Trạng thái";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(655, 256);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(283, 28);
            cmbStatus.TabIndex = 21;
            // 
            // panelHours
            // 
            panelHours.ColumnCount = 4;
            panelHours.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.251255F));
            panelHours.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.748745F));
            panelHours.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 101F));
            panelHours.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 97F));
            panelHours.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 69F));
            panelHours.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 62F));
            panelHours.Location = new Point(12, 335);
            panelHours.Name = "panelHours";
            panelHours.RowCount = 4;
            panelHours.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelHours.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelHours.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            panelHours.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            panelHours.Size = new Size(398, 171);
            panelHours.TabIndex = 22;
            // 
            // lblCustomerPhone
            // 
            lblCustomerPhone.AutoSize = true;
            lblCustomerPhone.Location = new Point(520, 94);
            lblCustomerPhone.Name = "lblCustomerPhone";
            lblCustomerPhone.Size = new Size(97, 20);
            lblCustomerPhone.TabIndex = 23;
            lblCustomerPhone.Text = "Số điện thoại";
            // 
            // txtCustomerPhone
            // 
            txtCustomerPhone.Location = new Point(655, 91);
            txtCustomerPhone.Name = "txtCustomerPhone";
            txtCustomerPhone.Size = new Size(283, 27);
            txtCustomerPhone.TabIndex = 24;
            // 
            // lblShowUserCreated
            // 
            lblShowUserCreated.AutoSize = true;
            lblShowUserCreated.Location = new Point(128, 661);
            lblShowUserCreated.Name = "lblShowUserCreated";
            lblShowUserCreated.Size = new Size(89, 20);
            lblShowUserCreated.TabIndex = 25;
            lblShowUserCreated.Text = "Nhân viên A";
            // 
            // lblShowHoursNumber
            // 
            lblShowHoursNumber.AutoSize = true;
            lblShowHoursNumber.Location = new Point(76, 538);
            lblShowHoursNumber.Name = "lblShowHoursNumber";
            lblShowHoursNumber.Size = new Size(17, 20);
            lblShowHoursNumber.TabIndex = 26;
            lblShowHoursNumber.Text = "0";
            // 
            // lblShowPricePerHour
            // 
            lblShowPricePerHour.AutoSize = true;
            lblShowPricePerHour.Location = new Point(655, 538);
            lblShowPricePerHour.Name = "lblShowPricePerHour";
            lblShowPricePerHour.Size = new Size(36, 20);
            lblShowPricePerHour.TabIndex = 27;
            lblShowPricePerHour.Text = "0.00";
            // 
            // lblShowTotal
            // 
            lblShowTotal.AutoSize = true;
            lblShowTotal.Location = new Point(655, 605);
            lblShowTotal.Name = "lblShowTotal";
            lblShowTotal.Size = new Size(36, 20);
            lblShowTotal.TabIndex = 28;
            lblShowTotal.Text = "0.00";
            // 
            // lblDateCreated
            // 
            lblDateCreated.AutoSize = true;
            lblDateCreated.Location = new Point(12, 694);
            lblDateCreated.Name = "lblDateCreated";
            lblDateCreated.Size = new Size(103, 20);
            lblDateCreated.TabIndex = 29;
            lblDateCreated.Text = "Ngày tạo đơn:";
            // 
            // lblShowDateCreated
            // 
            lblShowDateCreated.AutoSize = true;
            lblShowDateCreated.Location = new Point(128, 694);
            lblShowDateCreated.Name = "lblShowDateCreated";
            lblShowDateCreated.Size = new Size(85, 20);
            lblShowDateCreated.TabIndex = 30;
            lblShowDateCreated.Text = "01/01/2000";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(655, 684);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(137, 40);
            btnSave.TabIndex = 33;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(833, 684);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(137, 40);
            btnCancel.TabIndex = 34;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddBookingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 753);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblShowDateCreated);
            Controls.Add(lblDateCreated);
            Controls.Add(lblShowTotal);
            Controls.Add(lblShowPricePerHour);
            Controls.Add(lblShowHoursNumber);
            Controls.Add(lblShowUserCreated);
            Controls.Add(txtCustomerPhone);
            Controls.Add(lblCustomerPhone);
            Controls.Add(panelHours);
            Controls.Add(cmbStatus);
            Controls.Add(lblStatus);
            Controls.Add(lblUserCreated);
            Controls.Add(lblTotal);
            Controls.Add(lblPricePerHour);
            Controls.Add(lblHoursNumber);
            Controls.Add(dtpBookingDate);
            Controls.Add(lblBookingDate);
            Controls.Add(cmbFieldName);
            Controls.Add(lblFieldName);
            Controls.Add(cmbFieldType);
            Controls.Add(lblFieldType);
            Controls.Add(cmbCustomerName);
            Controls.Add(lblCustomerName);
            Controls.Add(lblTitle);
            Name = "AddBookingForm";
            Text = "AddBookingForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCustomerName;
        private ComboBox cmbCustomerName;
        private Label lblFieldType;
        private ComboBox cmbFieldType;
        private Label lblFieldName;
        private ComboBox cmbFieldName;
        private Label lblBookingDate;
        private DateTimePicker dtpBookingDate;
        private Label lblHoursNumber;
        private Label lblPricePerHour;
        private Label lblTotal;
        private Label lblUserCreated;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private TableLayoutPanel panelHours;
        private Label lblCustomerPhone;
        private TextBox txtCustomerPhone;
        private Label lblShowUserCreated;
        private Label lblShowHoursNumber;
        private Label lblShowPricePerHour;
        private Label lblShowTotal;
        private Label lblDateCreated;
        private Label lblShowDateCreated;
        private Button btnSave;
        private Button btnCancel;
    }
}