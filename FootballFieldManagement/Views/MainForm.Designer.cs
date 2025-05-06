using System.Drawing;

namespace FootballFieldManagement
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panelSideNav = new Panel();
            panelUserInfo = new Panel();
            lblUserRole = new Label();
            lblUserName = new Label();
            picAvtUser = new PictureBox();
            btnLogout = new Button();
            btnUser = new Button();
            btnField = new Button();
            btnCustomer = new Button();
            btnBooking = new Button();
            picLogo = new PictureBox();
            panelMainContent = new Panel();
            btnReport = new Button();
            panelSideNav.SuspendLayout();
            panelUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvtUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // panelSideNav
            // 
            panelSideNav.BackColor = Color.FromArgb(255, 255, 240);
            panelSideNav.Controls.Add(panelUserInfo);
            panelSideNav.Controls.Add(btnLogout);
            panelSideNav.Controls.Add(btnReport);
            panelSideNav.Controls.Add(btnUser);
            panelSideNav.Controls.Add(btnField);
            panelSideNav.Controls.Add(btnCustomer);
            panelSideNav.Controls.Add(btnBooking);
            panelSideNav.Controls.Add(picLogo);
            panelSideNav.Dock = DockStyle.Left;
            panelSideNav.Location = new Point(0, 0);
            panelSideNav.Name = "panelSideNav";
            panelSideNav.Padding = new Padding(16);
            panelSideNav.Size = new Size(240, 753);
            panelSideNav.TabIndex = 0;
            // 
            // panelUserInfo
            // 
            panelUserInfo.Controls.Add(lblUserRole);
            panelUserInfo.Controls.Add(lblUserName);
            panelUserInfo.Controls.Add(picAvtUser);
            panelUserInfo.Dock = DockStyle.Bottom;
            panelUserInfo.Location = new Point(16, 527);
            panelUserInfo.Name = "panelUserInfo";
            panelUserInfo.Padding = new Padding(10);
            panelUserInfo.Size = new Size(208, 160);
            panelUserInfo.TabIndex = 11;
            // 
            // lblUserRole
            // 
            lblUserRole.Dock = DockStyle.Top;
            lblUserRole.Location = new Point(10, 92);
            lblUserRole.Margin = new Padding(3);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(188, 20);
            lblUserRole.TabIndex = 8;
            lblUserRole.Text = "Chức vụ";
            lblUserRole.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUserName
            // 
            lblUserName.Dock = DockStyle.Top;
            lblUserName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUserName.Location = new Point(10, 72);
            lblUserName.Margin = new Padding(3);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(188, 20);
            lblUserName.TabIndex = 9;
            lblUserName.Text = "Tên nhân viên";
            lblUserName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picAvtUser
            // 
            picAvtUser.Dock = DockStyle.Top;
            picAvtUser.Image = Properties.Resources.profile;
            picAvtUser.Location = new Point(10, 10);
            picAvtUser.Name = "picAvtUser";
            picAvtUser.Size = new Size(188, 62);
            picAvtUser.SizeMode = PictureBoxSizeMode.Zoom;
            picAvtUser.TabIndex = 10;
            picAvtUser.TabStop = false;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 224, 192);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Image = (Image)resources.GetObject("btnLogout.Image");
            btnLogout.Location = new Point(16, 687);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(208, 50);
            btnLogout.TabIndex = 7;
            btnLogout.Text = " Đăng xuất";
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnUser
            // 
            btnUser.Dock = DockStyle.Top;
            btnUser.FlatAppearance.BorderSize = 0;
            btnUser.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 255, 160);
            btnUser.FlatStyle = FlatStyle.Flat;
            btnUser.Font = new Font("Segoe UI", 12F);
            btnUser.Image = (Image)resources.GetObject("btnUser.Image");
            btnUser.Location = new Point(16, 336);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(208, 80);
            btnUser.TabIndex = 4;
            btnUser.Text = " Nhân viên";
            btnUser.TextAlign = ContentAlignment.MiddleLeft;
            btnUser.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUser.UseVisualStyleBackColor = true;
            btnUser.Click += btnUser_Click;
            // 
            // btnField
            // 
            btnField.Dock = DockStyle.Top;
            btnField.FlatAppearance.BorderSize = 0;
            btnField.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 255, 160);
            btnField.FlatStyle = FlatStyle.Flat;
            btnField.Font = new Font("Segoe UI", 12F);
            btnField.Image = (Image)resources.GetObject("btnField.Image");
            btnField.Location = new Point(16, 256);
            btnField.Name = "btnField";
            btnField.Size = new Size(208, 80);
            btnField.TabIndex = 3;
            btnField.Text = " Quản lý sân";
            btnField.TextAlign = ContentAlignment.MiddleLeft;
            btnField.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnField.UseVisualStyleBackColor = true;
            btnField.Click += btnField_Click;
            // 
            // btnCustomer
            // 
            btnCustomer.Dock = DockStyle.Top;
            btnCustomer.FlatAppearance.BorderSize = 0;
            btnCustomer.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 255, 160);
            btnCustomer.FlatStyle = FlatStyle.Flat;
            btnCustomer.Font = new Font("Segoe UI", 12F);
            btnCustomer.Image = (Image)resources.GetObject("btnCustomer.Image");
            btnCustomer.Location = new Point(16, 176);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Size = new Size(208, 80);
            btnCustomer.TabIndex = 2;
            btnCustomer.Text = " Khách hàng";
            btnCustomer.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomer.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCustomer.UseVisualStyleBackColor = true;
            btnCustomer.Click += btnCustomer_Click;
            // 
            // btnBooking
            // 
            btnBooking.Dock = DockStyle.Top;
            btnBooking.FlatAppearance.BorderSize = 0;
            btnBooking.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 255, 160);
            btnBooking.FlatStyle = FlatStyle.Flat;
            btnBooking.Font = new Font("Segoe UI", 12F);
            btnBooking.ForeColor = SystemColors.ControlText;
            btnBooking.Image = (Image)resources.GetObject("btnBooking.Image");
            btnBooking.Location = new Point(16, 96);
            btnBooking.Name = "btnBooking";
            btnBooking.Size = new Size(208, 80);
            btnBooking.TabIndex = 1;
            btnBooking.Text = " Đặt sân";
            btnBooking.TextAlign = ContentAlignment.MiddleLeft;
            btnBooking.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBooking.UseVisualStyleBackColor = true;
            btnBooking.Click += btnBooking_Click;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Top;
            picLogo.Image = Properties.Resources._2A_logo;
            picLogo.Location = new Point(16, 16);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(208, 80);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // panelMainContent
            // 
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(240, 0);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Padding = new Padding(4);
            panelMainContent.Size = new Size(942, 753);
            panelMainContent.TabIndex = 1;
            // 
            // btnReport
            // 
            btnReport.Dock = DockStyle.Top;
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 255, 160);
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new Font("Segoe UI", 12F);
            btnReport.Image = (Image)resources.GetObject("btnReport.Image");
            btnReport.Location = new Point(16, 416);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(208, 80);
            btnReport.TabIndex = 5;
            btnReport.Text = " Thống kê";
            btnReport.TextAlign = ContentAlignment.MiddleLeft;
            btnReport.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReport.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 753);
            Controls.Add(panelMainContent);
            Controls.Add(panelSideNav);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sân bóng 2A";
            Load += MainForm_Load;
            panelSideNav.ResumeLayout(false);
            panelUserInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAvtUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSideNav;
        private Panel panelMainContent;
        private PictureBox picLogo;
        private Button btnBooking;
        private Button btnCustomer;
        private Button btnField;
        private Button btnUser;
        private Button btnLogout;
        private Label lblUserName;
        private PictureBox picAvtUser;
        private Label lblUserRole;
        private Panel panelUserInfo;
        private string imagePath;
        private Button btnReport;
    }
}
