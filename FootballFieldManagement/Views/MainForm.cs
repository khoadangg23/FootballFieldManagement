using FootballFieldManagement.Controllers;
using FootballFieldManagement.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FootballFieldManagement
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ISessionService _sessionService;
        private Form _activeChildForm = null;
        private Button _activeButton = null;

        public MainForm(IServiceProvider serviceProvider, ISessionService sessionService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _sessionService = sessionService;
            SetUserInfo();

        }

        private void SetUserInfo()
        {
            lblUserName.Text = _sessionService.GetCurrentUser().FullName;
            lblUserRole.Text = _sessionService.GetCurrentUser().Role;

            // Phân quyền menu dựa vào role
            if (_sessionService.GetCurrentUser().Role != "Admin")
            {
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Khi load form chính, tạo FieldForm bằng DI
            LoadChildForm(_serviceProvider.GetRequiredService<BookingForm>());
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
            // Khi click nút, tạo UserForm bằng DI
            LoadChildForm(_serviceProvider.GetRequiredService<BookingForm>());
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
            // Khi click nút, tạo UserForm bằng DI
            LoadChildForm(_serviceProvider.GetRequiredService<UserForm>());
            highlightButton((Button)sender);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _sessionService.ClearCurrentUser();
            this.Close();
        }
    }
}
