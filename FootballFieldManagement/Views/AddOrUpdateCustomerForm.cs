using System;
using System.Windows.Forms;
using FootballFieldManagement.Controllers;
using FootballFieldManagement.Models;

namespace FootballFieldManagement.Views
{
    public partial class AddOrUpdateCustomerForm : Form
    {
        private readonly CustomerController _customerController;
        private Customer _customer;
        private bool _isUpdateMode;

        public AddOrUpdateCustomerForm(CustomerController customerController)
        {
            InitializeComponent();
            _customerController = customerController;
            _isUpdateMode = false;
        }

        public AddOrUpdateCustomerForm(CustomerController customerController, Customer customer)
        {
            InitializeComponent();
            _customerController = customerController;
            _customer = customer;
            _isUpdateMode = true;
            LoadCustomerData();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(120, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(131, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thêm khách hàng";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(25, 60);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(92, 13);
            this.lblCustomerName.TabIndex = 1;
            this.lblCustomerName.Text = "Tên khách hàng:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(120, 57);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(220, 20);
            this.txtCustomerName.TabIndex = 0;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(25, 90);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(76, 13);
            this.lblPhoneNumber.TabIndex = 1;
            this.lblPhoneNumber.Text = "Số điện thoại:";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(120, 87);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(220, 20);
            this.txtPhoneNumber.TabIndex = 1;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(25, 120);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(120, 117);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(220, 20);
            this.txtEmail.TabIndex = 2;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(25, 150);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(43, 13);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.Text = "Địa chỉ:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(120, 147);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(220, 60);
            this.txtAddress.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(120, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(240, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddOrUpdateCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 271);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddOrUpdateCustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý khách hàng";
            this.Load += new System.EventHandler(this.AddOrUpdateCustomerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private void AddOrUpdateCustomerForm_Load(object sender, EventArgs e)
        {
            if (_isUpdateMode)
            {
                lblTitle.Text = "Cập nhật thông tin khách hàng";
            }
        }

        private void LoadCustomerData()
        {
            if (_customer != null)
            {
                txtCustomerName.Text = _customer.CustomerName;
                txtPhoneNumber.Text = _customer.PhoneNumber;
                txtEmail.Text = _customer.Email;
                txtAddress.Text = _customer.Address;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (_isUpdateMode)
                {
                    _customer.CustomerName = txtCustomerName.Text.Trim();
                    _customer.PhoneNumber = txtPhoneNumber.Text.Trim();
                    _customer.Email = txtEmail.Text.Trim();
                    _customer.Address = txtAddress.Text.Trim();

                    _customerController.UpdateCustomer(_customer);

                    MessageBox.Show("Cập nhật khách hàng thành công!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Add new 
                    var customer = new Customer
                    {
                        CustomerName = txtCustomerName.Text.Trim(),
                        PhoneNumber = txtPhoneNumber.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Address = txtAddress.Text.Trim()
                    };

                    _customerController.AddCustomer(customer);

                    MessageBox.Show("Thêm khách hàng thành công!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneNumber.Focus();
                return false;
            }

            //// Additional validation for phone number format
            //if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhoneNumber.Text, @"^\d{10}$"))
            //{
            //    MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập 10 số!", "Thông báo",
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtPhoneNumber.Focus();
            //    return false;
            //}

            //// Email validation if provided
            //if (!string.IsNullOrWhiteSpace(txtEmail.Text) &&
            //    !System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text,
            //    @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            //{
            //    MessageBox.Show("Email không hợp lệ!", "Thông báo",
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtEmail.Focus();
            //    return false;
            //}

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}