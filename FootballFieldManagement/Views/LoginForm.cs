using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FootballFieldManagement.Controllers;
using FootballFieldManagement.Services.Interfaces;

namespace FootballFieldManagement.Views
{
    public partial class LoginForm : Form
    {
        private readonly UserController _userController;
        private readonly ISessionService _sessionService;

        public LoginForm(UserController userController, ISessionService sessionService)
        {
            InitializeComponent();
            _userController = userController;
            _sessionService = sessionService;

            this.btnLogin.Click += btnLogin_Click;
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Cảnh báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_userController.ValidateUser(username, password))
            {
                var user = _userController.GetUserByUsername(username);

                // Lưu thông tin người dùng vào session
                _sessionService.SetCurrentUser(user);

                this.DialogResult = DialogResult.OK; // Báo hiệu đăng nhập thành công
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi đăng nhập",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
