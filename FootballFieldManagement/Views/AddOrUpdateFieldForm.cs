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
            PopulateFieldData();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFieldName = new System.Windows.Forms.Label();
            this.lblFieldType = new System.Windows.Forms.Label();
            this.lblPricePerHour = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtFieldName = new System.Windows.Forms.TextBox();
            this.cboFieldType = new System.Windows.Forms.ComboBox();
            this.numPricePerHour = new System.Windows.Forms.NumericUpDown();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPricePerHour)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(139, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Field";

            // lblFieldName
            this.lblFieldName.AutoSize = true;
            this.lblFieldName.Location = new System.Drawing.Point(12, 60);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(74, 15);
            this.lblFieldName.TabIndex = 1;
            this.lblFieldName.Text = "Tên Sân:";

            // lblFieldType
            this.lblFieldType.AutoSize = true;
            this.lblFieldType.Location = new System.Drawing.Point(12, 100);
            this.lblFieldType.Name = "lblFieldType";
            this.lblFieldType.Size = new System.Drawing.Size(67, 15);
            this.lblFieldType.TabIndex = 2;
            this.lblFieldType.Text = "Loại Sân:";

            // lblPricePerHour
            this.lblPricePerHour.AutoSize = true;
            this.lblPricePerHour.Location = new System.Drawing.Point(12, 140);
            this.lblPricePerHour.Name = "lblPricePerHour";
            this.lblPricePerHour.Size = new System.Drawing.Size(90, 15);
            this.lblPricePerHour.TabIndex = 3;
            this.lblPricePerHour.Text = "Giá mỗi giờ:";

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 180);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 15);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Trạng thái:";

            // txtFieldName
            this.txtFieldName.Location = new System.Drawing.Point(118, 57);
            this.txtFieldName.Name = "txtFieldName";
            this.txtFieldName.Size = new System.Drawing.Size(250, 23);
            this.txtFieldName.TabIndex = 5;

            // cboFieldType
            this.cboFieldType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFieldType.FormattingEnabled = true;
            this.cboFieldType.Location = new System.Drawing.Point(118, 97);
            this.cboFieldType.Name = "cboFieldType";
            this.cboFieldType.Size = new System.Drawing.Size(250, 23);
            this.cboFieldType.TabIndex = 6;

            // numPricePerHour
            this.numPricePerHour.DecimalPlaces = 2;
            this.numPricePerHour.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numPricePerHour.Location = new System.Drawing.Point(118, 138);
            this.numPricePerHour.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numPricePerHour.Name = "numPricePerHour";
            this.numPricePerHour.Size = new System.Drawing.Size(250, 23);
            this.numPricePerHour.TabIndex = 7;
            this.numPricePerHour.ThousandsSeparator = true;
            this.numPricePerHour.Value = new decimal(new int[] { 100000, 0, 0, 0 });

            // cboStatus
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(118, 177);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(250, 23);
            this.cboStatus.TabIndex = 8;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(118, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(248, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // FieldForm
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 271);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.numPricePerHour);
            this.Controls.Add(this.cboFieldType);
            this.Controls.Add(this.txtFieldName);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPricePerHour);
            this.Controls.Add(this.lblFieldType);
            this.Controls.Add(this.lblFieldName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddFieldForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Field";
            ((System.ComponentModel.ISupportInitialize)(this.numPricePerHour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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

        private void PopulateFieldData()
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