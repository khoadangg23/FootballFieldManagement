using System.Text;
using FootballFieldManagement.Controllers;
using FootballFieldManagement.Models;
using FootballFieldManagement.Views;

namespace FootballFieldManagement
{
    public partial class FieldForm : Form
    {
        private readonly FieldController _fieldController;

        public FieldForm(FieldController fieldController)
        {
            InitializeComponent();
            _fieldController = fieldController;

            this.Load += FieldForm_Load;
            btnAdd.Click += BtnAdd_Click;
            dgvFields.CellContentClick += dgvFields_CellContentClick;
            txtSearch.TextChanged += txtSearch_TextChanged;
            btnExport.Click += btnExport_Click;
        }

        public FieldForm()
        {
            InitializeComponent();
        }

        private void FieldForm_Load(object sender, EventArgs e)
        {
            // Load fields into the DataGridView
            LoadFields();
            ConfigureDataGridView();

            txtSearch.PlaceholderText = "Tìm ID Sân, Tên Sân hoặc Loại Sân";
        }

        private void LoadFields()
        {
            var fields = _fieldController.GetAllFields();
            bindingSourceField.DataSource = fields.ToList();
            dgvFields.DataSource = bindingSourceField;
        }

        private void ConfigureDataGridView()
        {
            //Đổi tiêu đề cột
            dgvFields.Columns["FieldId"].HeaderText = "ID Sân";
            dgvFields.Columns["FieldName"].HeaderText = "Tên Sân";
            dgvFields.Columns["FieldType"].HeaderText = "Loại Sân";
            dgvFields.Columns["PricePerHour"].HeaderText = "Giá mỗi giờ";
            dgvFields.Columns["Status"].HeaderText = "Trạng thái";
            // Ẩn cột
            dgvFields.Columns["BookingDetails"].Visible = false;

            // Thêm cột nút Sửa
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.Name = "EditColumn";
            btnEdit.HeaderText = "";
            btnEdit.Text = "Sửa";
            btnEdit.UseColumnTextForButtonValue = true;

            // Tùy chỉnh kiểu hiển thị của nút
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.DefaultCellStyle.BackColor = Color.LightYellow;
            btnEdit.DefaultCellStyle.Font = new Font(dgvFields.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            btnEdit.DefaultCellStyle.Padding = new Padding(2);
            dgvFields.Columns.Add(btnEdit);
            dgvFields.Columns["EditColumn"].Width = 60;
            dgvFields.Columns["EditColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            // Thêm cột nút Xóa
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "DeleteColumn";
            btnDelete.HeaderText = "";
            btnDelete.Text = "Xóa";
            btnDelete.UseColumnTextForButtonValue = true;

            // Tùy chỉnh kiểu hiển thị của nút
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.DefaultCellStyle.BackColor = Color.IndianRed;
            btnDelete.DefaultCellStyle.Font = new Font(dgvFields.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            btnDelete.DefaultCellStyle.Padding = new Padding(2);

            dgvFields.Columns.Add(btnDelete);
            dgvFields.Columns["DeleteColumn"].Width = 60;
            dgvFields.Columns["DeleteColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvFields.ReadOnly = true;
            dgvFields.AllowUserToAddRows = false;

            // Tự động điều chỉnh độ rộng dựa trên nội dung và tiêu đề
            dgvFields.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Đặt kiểu chữ cho tiêu đề cột
            dgvFields.ColumnHeadersDefaultCellStyle.Font = new Font(dgvFields.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

            // Chọn cả hàng
            dgvFields.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Không cho chọn nhiều hàng
            dgvFields.MultiSelect = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddOrUpdateFieldForm(_fieldController))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh your fields list here
                    LoadFields();
                }
            }
        }

        private void dgvFields_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header row
            if (e.ColumnIndex < 0) return; // Ignore header column

            // Ignore other columns
            if (dgvFields.Columns[e.ColumnIndex].Name != "EditColumn"
                && dgvFields.Columns[e.ColumnIndex].Name != "DeleteColumn")
                return;

            var fieldId = (int)dgvFields.Rows[e.RowIndex].Cells["FieldId"].Value;
            var field = (Field)dgvFields.CurrentRow.DataBoundItem;

            if (dgvFields.Columns[e.ColumnIndex].Name == "EditColumn")
            {
                using (var editForm = new AddOrUpdateFieldForm(_fieldController, field))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadFields();
                    }
                }
            }
            else if (dgvFields.Columns[e.ColumnIndex].Name == "DeleteColumn")
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sân này không?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _fieldController.DeleteField(fieldId);
                    LoadFields();
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
            var fields = _fieldController.GetAllFields()
                .Where(f =>
                    f.FieldId.ToString().Contains(keyword) ||
                    f.FieldName.ToLower().Contains(keyword) ||
                    f.FieldType.ToLower().Contains(keyword)
                );

            bindingSourceField.DataSource = fields.ToList();
            dgvFields.DataSource = bindingSourceField;
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
            saveFileDialog.FileName = "Fields";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fields = _fieldController.GetAllFields();

                var lines = new List<string>();
                lines.Add("FieldId;FieldName;FieldType;PricePerHour;Status");

                foreach (var f in fields)
                {
                    lines.Add($"{f.FieldId};{f.FieldName};{f.FieldType};{f.PricePerHour};{f.Status}");
                }

                File.WriteAllLines(saveFileDialog.FileName, lines, new UTF8Encoding(true));
                MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
