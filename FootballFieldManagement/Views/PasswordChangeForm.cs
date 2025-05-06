using System;
using System.Windows.Forms;
using FootballFieldManagement.Services.Interfaces;

namespace FootballFieldManagement.Views
{
    public partial class PasswordChangeForm : Form
    {
        private readonly ISessionService _sessionService;
        private readonly IUserService _userService;
        public PasswordChangeForm(IUserService userService, ISessionService sessionService)
        {
            InitializeComponent();
            _userService = userService;
            _sessionService = sessionService;
        }

        private void InitializeComponent()
        {
            this.lblCurrentPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblCurrentPassword
            this.lblCurrentPassword.AutoSize = true;
            this.lblCurrentPassword.Location = new System.Drawing.Point(30, 30);
            this.lblCurrentPassword.Name = "lblCurrentPassword";
            this.lblCurrentPassword.Size = new System.Drawing.Size(120, 17);
            this.lblCurrentPassword.TabIndex = 0;
            this.lblCurrentPassword.Text = "Mật khẩu hiện tại:";

            // lblNewPassword
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(30, 70);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(120, 17);
            this.lblNewPassword.TabIndex = 1;
            this.lblNewPassword.Text = "Mật khẩu mới:";

            // lblConfirmPassword
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(30, 110);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(120, 17);
            this.lblConfirmPassword.TabIndex = 2;
            this.lblConfirmPassword.Text = "Xác nhận mật khẩu:";

            // txtCurrentPassword
            this.txtCurrentPassword.Location = new System.Drawing.Point(160, 30);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PasswordChar = '*';
            this.txtCurrentPassword.Size = new System.Drawing.Size(200, 22);
            this.txtCurrentPassword.TabIndex = 3;

            // txtNewPassword
            this.txtNewPassword.Location = new System.Drawing.Point(160, 70);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(200, 22);
            this.txtNewPassword.TabIndex = 4;

            // txtConfirmPassword
            this.txtConfirmPassword.Location = new System.Drawing.Point(160, 110);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(200, 22);
            this.txtConfirmPassword.TabIndex = 5;

            // btnChange
            this.btnChange.Location = new System.Drawing.Point(160, 160);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(90, 30);
            this.btnChange.TabIndex = 6;
            this.btnChange.Text = "Đổi";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(270, 160);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // PasswordChangeForm
            this.ClientSize = new System.Drawing.Size(394, 221);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtCurrentPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.lblCurrentPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordChangeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblCurrentPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnCancel;

        private void btnChange_Click(object sender, EventArgs e)
        {
            // Sample code for the Change button click event
            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                MessageBox.Show("Vui lòng xác nhận mật khẩu mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            string passwordInput = txtCurrentPassword.Text;

            if (!isCorrectPassword(passwordInput))
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the new password is different from the current password
            if (txtNewPassword.Text == passwordInput)
            {
                MessageBox.Show("Mật khẩu mới không được giống mật khẩu hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the new password is strong enough
            if (txtNewPassword.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If all checks pass, proceed to change the password
            ChangePassword(txtNewPassword.Text);

            // For this example, we'll just show a success message
            MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private bool isCorrectPassword(string passwordInput)
        {
            string currentPassword = _sessionService.GetCurrentUser().PasswordHash;
            if (passwordInput == currentPassword)
                return true;
            return false;
        }

        private void ChangePassword(string newPassword)
        {
            var user = _sessionService.GetCurrentUser();
            user.PasswordHash = newPassword;
            _userService.UpdateUser(user);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}