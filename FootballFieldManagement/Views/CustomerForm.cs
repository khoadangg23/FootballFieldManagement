using System.Text;
using FootballFieldManagement.Controllers;
using FootballFieldManagement.Models;
using FootballFieldManagement.Views;

namespace FootballFieldManagement
{
    public partial class CustomerForm : Form
    {
        private readonly CustomerController _customerController;

        public CustomerForm(CustomerController customerController)
        {
            InitializeComponent();
            _customerController = customerController;

            this.Load += CustomerForm_Load;
            btnAdd.Click += BtnAdd_Click;
            dgvCustomers.CellContentClick += dgvCustomers_CellContentClick;
            txtSearch.TextChanged += txtSearch_TextChanged;
            btnExport.Click += btnExport_Click;
        }


        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            ConfigureDataGridView();

            txtSearch.PlaceholderText = "Tìm ID, tên hoặc số điện thoại khách hàng";
        }

        private void LoadCustomers()
        {
            var customers = _customerController.GetAllCustomers();
            bindingSourceField.DataSource = customers.ToList();
            dgvCustomers.DataSource = bindingSourceField;
        }

        private void ConfigureDataGridView()
        {
            //Đổi tiêu đề cột
            dgvCustomers.Columns["CustomerId"].HeaderText = "ID Khách hàng";
            dgvCustomers.Columns["CustomerName"].HeaderText = "Tên Khách hàng";
            dgvCustomers.Columns["PhoneNumber"].HeaderText = "Số điện thoại";
            dgvCustomers.Columns["Email"].HeaderText = "Email";
            dgvCustomers.Columns["Address"].HeaderText = "Địa chỉ";
            // Ẩn cột
            dgvCustomers.Columns["Bookings"].Visible = false;

            // Thêm cột nút Sửa
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.Name = "EditColumn";
            btnEdit.HeaderText = "";
            btnEdit.Text = "Sửa";
            btnEdit.UseColumnTextForButtonValue = true;

            // Tùy chỉnh kiểu hiển thị của nút
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.DefaultCellStyle.BackColor = Color.LightYellow;
            btnEdit.DefaultCellStyle.Font = new Font(dgvCustomers.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            btnEdit.DefaultCellStyle.Padding = new Padding(2);
            dgvCustomers.Columns.Add(btnEdit);
            dgvCustomers.Columns["EditColumn"].Width = 60;
            dgvCustomers.Columns["EditColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            // Thêm cột nút Xóa
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "DeleteColumn";
            btnDelete.HeaderText = "";
            btnDelete.Text = "Xóa";
            btnDelete.UseColumnTextForButtonValue = true;

            // Tùy chỉnh kiểu hiển thị của nút
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.DefaultCellStyle.BackColor = Color.IndianRed;
            btnDelete.DefaultCellStyle.Font = new Font(dgvCustomers.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            btnDelete.DefaultCellStyle.Padding = new Padding(2);

            dgvCustomers.Columns.Add(btnDelete);
            dgvCustomers.Columns["DeleteColumn"].Width = 60;
            dgvCustomers.Columns["DeleteColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvCustomers.ReadOnly = true;
            dgvCustomers.AllowUserToAddRows = false;

            // Tự động điều chỉnh độ rộng dựa trên nội dung và tiêu đề
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Đặt kiểu chữ cho tiêu đề cột
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new Font(dgvCustomers.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

            // Chọn cả hàng
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Không cho chọn nhiều hàng
            dgvCustomers.MultiSelect = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddOrUpdateCustomerForm(_customerController))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    // reload
                    LoadCustomers();
                }
            }
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header row
            if (e.ColumnIndex < 0) return; // Ignore header column

            // Ignore other columns
            if (dgvCustomers.Columns[e.ColumnIndex].Name != "EditColumn"
                && dgvCustomers.Columns[e.ColumnIndex].Name != "DeleteColumn")
                return;

            var customer = (Customer)dgvCustomers.CurrentRow.DataBoundItem;

            if (dgvCustomers.Columns[e.ColumnIndex].Name == "EditColumn")
            {
                using (var editForm = new AddOrUpdateCustomerForm(_customerController, customer))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadCustomers();
                    }
                }
            }
            else if (dgvCustomers.Columns[e.ColumnIndex].Name == "DeleteColumn")
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa Khách hàng này không?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _customerController.DeleteCustomer(customer.CustomerId);

                    MessageBox.Show("Xóa Khách hàng thành công!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadCustomers();
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
            var customers = _customerController.GetAllCustomers()
                .Where(c =>
                    c.CustomerId.ToString().Contains(keyword) ||
                    c.CustomerName.ToLower().Contains(keyword) ||
                    c.PhoneNumber.ToLower().Contains(keyword)
                );

            bindingSourceField.DataSource = customers.ToList();
            dgvCustomers.DataSource = bindingSourceField;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToCsv();
        }

        private void ExportToCsv()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
            saveFileDialog.Title = "Xuất file danh sách Sân";
            saveFileDialog.FileName = "Customers";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var customers = _customerController.GetAllCustomers();

                var lines = new List<string>();
                lines.Add("CustomerId;CutomerName;PhoneNumber;Email;Address");

                foreach (var c in customers)
                {
                    lines.Add($"{c.CustomerId};{c.CustomerName};{c.PhoneNumber};{c.Email};{c.Address}");
                }

                File.WriteAllLines(saveFileDialog.FileName, lines, new UTF8Encoding(true));
                MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
