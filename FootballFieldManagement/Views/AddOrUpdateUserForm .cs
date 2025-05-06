using System;
using System.Windows.Forms;
using FootballFieldManagement.Controllers;
using FootballFieldManagement.Models;

namespace FootballFieldManagement.Views
{
    public partial class AddOrUpdateUserForm : Form
    {
        private readonly UserController _userController;
        private User _user;
        private bool _isUpdateMode;

        public AddOrUpdateUserForm(UserController userController)
        {
            InitializeComponent();
            _userController = userController;
            _isUpdateMode = false;
        }

        public AddOrUpdateUserForm(UserController userController, User user)
        {
            InitializeComponent();
            _userController = userController;
            _user = user;
            _isUpdateMode = true;
            LoadCustomerData();
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblPhoneNumber = new Label();
            txtPhoneNumber = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            txtUsername = new TextBox();
            lblUsername = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(160, 23);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(167, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Thêm nhân viên";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(32, 177);
            lblFullName.Margin = new Padding(4, 0, 4, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(102, 20);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Tên nhân viên:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(159, 173);
            txtFullName.Margin = new Padding(4, 5, 4, 5);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(292, 27);
            txtFullName.TabIndex = 0;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(32, 223);
            lblPhoneNumber.Margin = new Padding(4, 0, 4, 0);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(100, 20);
            lblPhoneNumber.TabIndex = 1;
            lblPhoneNumber.Text = "Số điện thoại:";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(159, 219);
            txtPhoneNumber.Margin = new Padding(4, 5, 4, 5);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(292, 27);
            txtPhoneNumber.TabIndex = 1;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(32, 270);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(159, 265);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(292, 27);
            txtEmail.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(160, 338);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(133, 46);
            btnSave.TabIndex = 4;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(320, 338);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(133, 46);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(159, 77);
            txtUsername.Margin = new Padding(4, 5, 4, 5);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(292, 27);
            txtUsername.TabIndex = 6;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(32, 81);
            lblUsername.Margin = new Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(100, 20);
            lblUsername.TabIndex = 7;
            lblUsername.Text = "Tên tài khoản:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(159, 124);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(292, 27);
            txtPassword.TabIndex = 8;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(32, 127);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 9;
            lblPassword.Text = "Mật khẩu:";
            // 
            // AddOrUpdateUserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(485, 417);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtPhoneNumber);
            Controls.Add(lblPhoneNumber);
            Controls.Add(txtFullName);
            Controls.Add(lblFullName);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddOrUpdateUserForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý khách hàng";
            Load += AddOrUpdateCustomerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private void AddOrUpdateCustomerForm_Load(object sender, EventArgs e)
        {
            if (_isUpdateMode)
            {
                lblTitle.Text = "Cập nhật thông tin nhân viên";
            }
        }

        private void LoadCustomerData()
        {
            if (_user != null)
            {
                txtUsername.Text = _user.Username;
                txtFullName.Text = _user.FullName;
                txtPhoneNumber.Text = _user.PhoneNumber;
                txtEmail.Text = _user.Email;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (_isUpdateMode)
                {
                    _user.FullName = txtFullName.Text.Trim();
                    _user.PhoneNumber = txtPhoneNumber.Text.Trim();
                    _user.Email = txtEmail.Text.Trim();

                    _userController.UpdateUser(_user);

                    MessageBox.Show("Cập nhật nhân viên thành công!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Add new 
                    var user = new User
                    {
                        Username = txtUsername.Text.Trim(),
                        PasswordHash = txtPassword.Text.Trim(), // Hash the password before saving
                        FullName = txtFullName.Text.Trim(),
                        PhoneNumber = txtPhoneNumber.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Role = "Staff",
                        IsActive = true
                    };

                    _userController.AddUser(user);

                    MessageBox.Show("Thêm nhân viên thành công!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
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