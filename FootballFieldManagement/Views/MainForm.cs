using FootballFieldManagement.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace FootballFieldManagement
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private Form _activeChildForm = null;
        private Button _activeButton = null;

        public MainForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            //SetUserInfo();

        }

        //private void SetUserInfo()
        //{
        //    lblUserName.Text = AppSession.CurrentUser.FullName;
        //    lblRole.Text = AppSession.CurrentUser.Role;

        //    // Phân quyền menu dựa vào role
        //    if (AppSession.CurrentUser.Role != "Admin")
        //    {
        //        btnUserManagement.Visible = false;
        //    }
        //}

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Khi load form chính, tạo FieldForm bằng DI
            LoadChildForm(_serviceProvider.GetRequiredService<FieldForm>());
        }

        private void LoadChildForm(Form childForm)
        {
            if (_activeChildForm != null)
            {
                _activeChildForm.Close();
            }

            _activeChildForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMainContent.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void highlightButton(Button button)
        {
            if (_activeButton != null)
            {
                _activeButton.BackColor = Color.FromArgb(255, 255, 240);
            }
            _activeButton = button;
            _activeButton.BackColor = Color.FromArgb(160, 255, 160);
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            LoadChildForm(new FieldForm());
            highlightButton((Button)sender);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            // Khi click nút, tạo CustomerForm bằng DI
            LoadChildForm(_serviceProvider.GetRequiredService<CustomerForm>());
            highlightButton((Button)sender);
        }

        private void btnField_Click(object sender, EventArgs e)
        {
            // Khi click nút, tạo FieldForm bằng DI
            LoadChildForm(_serviceProvider.GetRequiredService<FieldForm>());
            highlightButton((Button)sender);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            LoadChildForm(new FieldForm());
            highlightButton((Button)sender);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
