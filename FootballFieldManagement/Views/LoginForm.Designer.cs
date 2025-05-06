namespace FootballFieldManagement.Views
{
    partial class LoginForm
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
            panelLeft = new Panel();
            pictureBoxLogo = new PictureBox();
            panelRight = new Panel();
            lblError = new Label();
            btnLogin = new Button();
            chkShowPassword = new CheckBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblTitle = new Label();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panelRight.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.MidnightBlue;
            panelLeft.Controls.Add(pictureBoxLogo);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(300, 450);
            panelLeft.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.MidnightBlue;
            pictureBoxLogo.Dock = DockStyle.Fill;
            pictureBoxLogo.Image = Properties.Resources._2A_logo;
            pictureBoxLogo.Location = new Point(0, 0);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(300, 450);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(lblError);
            panelRight.Controls.Add(btnLogin);
            panelRight.Controls.Add(chkShowPassword);
            panelRight.Controls.Add(lblPassword);
            panelRight.Controls.Add(txtPassword);
            panelRight.Controls.Add(lblUsername);
            panelRight.Controls.Add(txtUsername);
            panelRight.Controls.Add(lblTitle);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(300, 0);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(500, 450);
            panelRight.TabIndex = 1;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Segoe UI", 10F);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(65, 320);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 23);
            lblError.TabIndex = 5;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.MidnightBlue;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(65, 363);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(375, 48);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Cursor = Cursors.Hand;
            chkShowPassword.Font = new Font("Segoe UI", 10F);
            chkShowPassword.ForeColor = Color.DarkSlateGray;
            chkShowPassword.Location = new Point(65, 277);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(144, 27);
            chkShowPassword.TabIndex = 3;
            chkShowPassword.Text = "Hiện mật khẩu";
            chkShowPassword.UseVisualStyleBackColor = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPassword.ForeColor = Color.DarkSlateGray;
            lblPassword.Location = new Point(65, 194);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(101, 28);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password";
            lblPassword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Cursor = Cursors.IBeam;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.ForeColor = SystemColors.ControlText;
            txtPassword.Location = new Point(65, 234);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Nhập mật khẩu";
            txtPassword.Size = new Size(375, 32);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblUsername.ForeColor = Color.DarkSlateGray;
            lblUsername.Location = new Point(65, 97);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(106, 28);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username";
            lblUsername.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Cursor = Cursors.IBeam;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.ForeColor = SystemColors.ControlText;
            txtUsername.Location = new Point(65, 137);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Nhập tên tài khoản";
            txtUsername.Size = new Size(375, 32);
            txtUsername.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.MidnightBlue;
            lblTitle.Location = new Point(102, 33);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(278, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đăng nhập hệ thống";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            AccessibleRole = AccessibleRole.TitleBar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLeft;
        private PictureBox pictureBoxLogo;
        private Panel panelRight;
        private Label lblTitle;
        private TextBox txtUsername;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private CheckBox chkShowPassword;
        private Label lblError;
    }
}