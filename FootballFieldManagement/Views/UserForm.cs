using System.Text;
using FootballFieldManagement.Controllers;
using FootballFieldManagement.Models;
using FootballFieldManagement.Views;

namespace FootballFieldManagement
{
    public partial class UserForm : Form
    {
        private readonly UserController _userController;

        public UserForm(UserController userController)
        {
            InitializeComponent();
            _userController = userController;

            this.Load += UserForm_Load;
            btnAdd.Click += BtnAdd_Click;
            dgvUsers.CellContentClick += dgvUsers_CellContentClick;
            txtSearch.TextChanged += txtSearch_TextChanged;
        }


        private void UserForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
            ConfigureDataGridView();

            txtSearch.PlaceholderText = "Tìm ID hoặc tên nhân viên";
        }

        private void LoadUsers()
        {
            var users = _userController.GetAllUsers();
            bindingSourceUser.DataSource = users.ToList();
            dgvUsers.DataSource = bindingSourceUser;
        }

        private void ConfigureDataGridView()
        {
            //Đổi tiêu đề cột
            //dgvCustomers.Columns["UserId"].HeaderText = "ID Nhân viên";
            //dgvCustomers.Columns["CustomerName"].HeaderText = "Tên Khách hàng";
            //dgvCustomers.Columns["PhoneNumber"].HeaderText = "Số điện thoại";
            //dgvCustomers.Columns["Email"].HeaderText = "Email";
            //dgvCustomers.Columns["Address"].HeaderText = "Địa chỉ";
            //// Ẩn cột
            //dgvCustomers.Columns["Bookings"].Visible = false;

            // Thêm cột nút Sửa
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.Name = "EditColumn";
            btnEdit.HeaderText = "";
            btnEdit.Text = "Sửa";
            btnEdit.UseColumnTextForButtonValue = true;

            // Tùy chỉnh kiểu hiển thị của nút
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.DefaultCellStyle.BackColor = Color.LightYellow;
            btnEdit.DefaultCellStyle.Font = new Font(dgvUsers.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            btnEdit.DefaultCellStyle.Padding = new Padding(2);
            dgvUsers.Columns.Add(btnEdit);
            dgvUsers.Columns["EditColumn"].Width = 60;
            dgvUsers.Columns["EditColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            // Thêm cột nút Xóa
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "DeleteColumn";
            btnDelete.HeaderText = "";
            btnDelete.Text = "Xóa";
            btnDelete.UseColumnTextForButtonValue = true;

            // Tùy chỉnh kiểu hiển thị của nút
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.DefaultCellStyle.BackColor = Color.IndianRed;
            btnDelete.DefaultCellStyle.Font = new Font(dgvUsers.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            btnDelete.DefaultCellStyle.Padding = new Padding(2);

            dgvUsers.Columns.Add(btnDelete);
            dgvUsers.Columns["DeleteColumn"].Width = 60;
            dgvUsers.Columns["DeleteColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvUsers.ReadOnly = true;
            dgvUsers.AllowUserToAddRows = false;

            // Tự động điều chỉnh độ rộng dựa trên nội dung và tiêu đề
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Đặt kiểu chữ cho tiêu đề cột
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font(dgvUsers.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

            // Chọn cả hàng
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Không cho chọn nhiều hàng
            dgvUsers.MultiSelect = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddOrUpdateUserForm(_userController))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    // reload
                    LoadUsers();
                }
            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header row
            if (e.ColumnIndex < 0) return; // Ignore header column

            // Ignore other columns
            if (dgvUsers.Columns[e.ColumnIndex].Name != "EditColumn"
                && dgvUsers.Columns[e.ColumnIndex].Name != "DeleteColumn")
                return;

            var user = (User)dgvUsers.CurrentRow.DataBoundItem;

            if (dgvUsers.Columns[e.ColumnIndex].Name == "EditColumn")
            {
                using (var editForm = new AddOrUpdateUserForm(_userController, user))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadUsers();
                    }
                }
            }
            else if (dgvUsers.Columns[e.ColumnIndex].Name == "DeleteColumn")
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa Khách hàng này không?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _userController.DeleteUser(user.UserId);

                    MessageBox.Show("Xóa Khách hàng thành công!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadUsers();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search(txtSearch.Text);
        }

        private void Search(string keyword)
        {
            keyword = keyword.Trim().ToLower();
            var users = _userController.GetAllUsers()
                .Where(u =>
                    u.UserId.ToString().Contains(keyword) ||
                    u.FullName.ToLower().Contains(keyword)
                );

            bindingSourceUser.DataSource = users.ToList();
            dgvUsers.DataSource = bindingSourceUser;
        }
    }
}
