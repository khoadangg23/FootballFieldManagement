using System;
using System.Windows.Forms;
using FootballFieldManagement.Controllers;
using FootballFieldManagement.Models;

namespace FootballFieldManagement.Views
{
    public partial class AddOrUpdateFieldForm : Form
    {
        // Define field status options
        private readonly string[] statusOptions = { "Có sẵn", "Đã đặt", "Bảo trì" };
        // Define field type options
        private readonly string[] fieldTypeOptions = { "Sân 5", "Sân 7", "Sân 11" };
        private bool _isUpdateMode;
        private Field _currentField;
        private readonly FieldController _fieldController;

        public AddOrUpdateFieldForm(FieldController fieldController)
        {
            InitializeComponent();
            _fieldController = fieldController;
            _isUpdateMode = false;
            this.Text = "Thêm Sân mới";
            lblTitle.Text = "Thêm Sân mới";
            LoadFieldTypes();
            LoadStatusOptions();
        }

        // Constructor for Update mode
        public AddOrUpdateFieldForm(FieldController fieldController, Field field)
        {
            InitializeComponent();
            _fieldController = fieldController;
            _isUpdateMode = true;
            _currentField = field;
            this.Text = "Cập nhật Sân";
            lblTitle.Text = "Cập nhật sân";
            LoadFieldTypes();
            LoadStatusOptions();
            LoadFieldData();
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblFieldName = new Label();
            lblFieldType = new Label();
            lblPricePerHour = new Label();
            lblStatus = new Label();
            txtFieldName = new TextBox();
            cboFieldType = new ComboBox();
            numPricePerHour = new NumericUpDown();
            cboStatus = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numPricePerHour).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(14, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(180, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add New Field";
            // 
            // lblFieldName
            // 
            lblFieldName.AutoSize = true;
            lblFieldName.Location = new Point(14, 80);
            lblFieldName.Name = "lblFieldName";
            lblFieldName.Size = new Size(63, 20);
            lblFieldName.TabIndex = 1;
            lblFieldName.Text = "Tên Sân:";
            // 
            // lblFieldType
            // 
            lblFieldType.AutoSize = true;
            lblFieldType.Location = new Point(14, 133);
            lblFieldType.Name = "lblFieldType";
            lblFieldType.Size = new Size(68, 20);
            lblFieldType.TabIndex = 2;
            lblFieldType.Text = "Loại Sân:";
            // 
            // lblPricePerHour
            // 
            lblPricePerHour.AutoSize = true;
            lblPricePerHour.Location = new Point(14, 187);
            lblPricePerHour.Name = "lblPricePerHour";
            lblPricePerHour.Size = new Size(90, 20);
            lblPricePerHour.TabIndex = 3;
            lblPricePerHour.Text = "Giá mỗi giờ:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(14, 240);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(78, 20);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Trạng thái:";
            // 
            // txtFieldName
            // 
            txtFieldName.Location = new Point(135, 76);
            txtFieldName.Margin = new Padding(3, 4, 3, 4);
            txtFieldName.Name = "txtFieldName";
            txtFieldName.Size = new Size(285, 27);
            txtFieldName.TabIndex = 5;
            // 
            // cboFieldType
            // 
            cboFieldType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFieldType.FormattingEnabled = true;
            cboFieldType.Location = new Point(135, 129);
            cboFieldType.Margin = new Padding(3, 4, 3, 4);
            cboFieldType.Name = "cboFieldType";
            cboFieldType.Size = new Size(285, 28);
            cboFieldType.TabIndex = 6;
            // 
            // numPricePerHour
            // 
            numPricePerHour.DecimalPlaces = 2;
            numPricePerHour.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            numPricePerHour.Location = new Point(135, 184);
            numPricePerHour.Margin = new Padding(3, 4, 3, 4);
            numPricePerHour.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numPricePerHour.Name = "numPricePerHour";
            numPricePerHour.Size = new Size(286, 27);
            numPricePerHour.TabIndex = 7;
            numPricePerHour.ThousandsSeparator = true;
            numPricePerHour.Value = new decimal(new int[] { 100000, 0, 0, 0 });
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(135, 236);
            cboStatus.Margin = new Padding(3, 4, 3, 4);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(285, 28);
            cboStatus.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(135, 293);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(137, 40);
            btnSave.TabIndex = 9;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(283, 293);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(137, 40);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddOrUpdateFieldForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(439, 361);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cboStatus);
            Controls.Add(numPricePerHour);
            Controls.Add(cboFieldType);
            Controls.Add(txtFieldName);
            Controls.Add(lblStatus);
            Controls.Add(lblPricePerHour);
            Controls.Add(lblFieldType);
            Controls.Add(lblFieldName);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddOrUpdateFieldForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add New Field";
            ((System.ComponentModel.ISupportInitialize)numPricePerHour).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFieldName;
        private System.Windows.Forms.Label lblFieldType;
        private System.Windows.Forms.Label lblPricePerHour;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtFieldName;
        private System.Windows.Forms.ComboBox cboFieldType;
        private System.Windows.Forms.NumericUpDown numPricePerHour;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private void LoadFieldTypes()
        {
            cboFieldType.Items.Clear();
            foreach (var type in fieldTypeOptions)
            {
                cboFieldType.Items.Add(type);
            }
            if (cboFieldType.Items.Count > 0)
                cboFieldType.SelectedIndex = 0;
        }

        private void LoadStatusOptions()
        {
            cboStatus.Items.Clear();
            foreach (var status in statusOptions)
            {
                cboStatus.Items.Add(status);
            }
            if (cboStatus.Items.Count > 0)
                cboStatus.SelectedIndex = 0;
        }

        private void LoadFieldData()
        {
            if (_currentField != null)
            {
                txtFieldName.Text = _currentField.FieldName;

                // Set field type
                if (!string.IsNullOrEmpty(_currentField.FieldType))
                {
                    int index = cboFieldType.FindStringExact(_currentField.FieldType);
                    if (index != -1)
                        cboFieldType.SelectedIndex = index;
                }

                // Set price
                numPricePerHour.Value = _currentField.PricePerHour;

                // Set status
                if (!string.IsNullOrEmpty(_currentField.Status))
                {
                    int index = cboStatus.FindStringExact(_currentField.Status);
                    if (index != -1)
                        cboStatus.SelectedIndex = index;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                if (_isUpdateMode)
                {
                    // Update existing field
                    _currentField.FieldName = txtFieldName.Text.Trim();
                    _currentField.FieldType = cboFieldType.SelectedItem.ToString();
                    _currentField.PricePerHour = numPricePerHour.Value;
                    _currentField.Status = cboStatus.SelectedItem.ToString();

                    _fieldController.UpdateField(_currentField);
                }
                else
                {
                    // Add new field
                    Field newField = new Field
                    {
                        FieldName = txtFieldName.Text.Trim(),
                        FieldType = cboFieldType.SelectedItem.ToString(),
                        PricePerHour = numPricePerHour.Value,
                        Status = cboStatus.SelectedItem.ToString()
                    };

                    _fieldController.AddField(newField);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                string action = _isUpdateMode ? "updating" : "adding";
                MessageBox.Show($"Error {action} field: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFieldName.Text))
            {
                MessageBox.Show("Tên Sân không được trống.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFieldName.Focus();
                return false;
            }

            if (cboFieldType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a field type.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboFieldType.Focus();
                return false;
            }

            if (numPricePerHour.Value <= 0)
            {
                MessageBox.Show("Giá phải lớn hơn 0.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPricePerHour.Focus();
                return false;
            }

            if (cboStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a status.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboStatus.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}