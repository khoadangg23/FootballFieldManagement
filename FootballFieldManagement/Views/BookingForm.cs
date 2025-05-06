using System.Text;
using FootballFieldManagement.Controllers;
using FootballFieldManagement.Models;
using FootballFieldManagement.Views;
using Microsoft.Extensions.DependencyInjection;

namespace FootballFieldManagement
{
    public partial class BookingForm : Form
    {
        private readonly BookingController _bookingController;
        private readonly IServiceProvider _serviceProvider;

        public BookingForm(BookingController bookingController, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _bookingController = bookingController;
            _serviceProvider = serviceProvider;

            this.Load += BookingForm_Load;
            btnAdd.Click += BtnAdd_Click;
            dgvBookings.CellContentClick += dgvFields_CellContentClick;
            txtSearch.TextChanged += txtSearch_TextChanged;
            _serviceProvider = serviceProvider;
            //btnExport.Click += btnExport_Click;
        }

        private void BookingForm_Load(object sender, EventArgs e)
        {
            // Load fields into the DataGridView
            LoadBookings();
            ConfigureDataGridView();

            txtSearch.PlaceholderText = "Tìm ID đơn, tên khách hàng";
        }

        private void LoadBookings()
        {
            var bookings = _bookingController.GetAllBookings();
            bindingSourceBooking.DataSource = bookings
                .Select(b => {
                    var detail = b.BookingDetails.FirstOrDefault();
                    return new
                    {
                        BookingId = b.BookingId,
                        CustomerName = b.Customer.CustomerName,
                        FieldType = detail?.Field?.FieldType ?? "",
                        BookingDate = b.BookingDate,
                        StartTime = detail?.StartTime,
                        EndTime = detail?.EndTime,
                        DurationHours = detail?.DurationHours ?? 0,
                        Status = b.Status
                    };
                })
                .ToList();

            dgvBookings.DataSource = bindingSourceBooking;
        }

        private void ConfigureDataGridView()
        {
            //Đổi tiêu đề cột
            //dgvBookings.Columns["FieldId"].HeaderText = "ID Sân";
            //dgvBookings.Columns["FieldName"].HeaderText = "Tên Sân";
            //dgvBookings.Columns["FieldType"].HeaderText = "Loại Sân";
            //dgvBookings.Columns["PricePerHour"].HeaderText = "Giá mỗi giờ";
            //dgvBookings.Columns["Status"].HeaderText = "Trạng thái";
            //// Ẩn cột
            //dgvBookings.Columns["UserId"].Visible = false;
            //dgvBookings.Columns["Payments"].Visible = false;
            //dgvBookings.Columns["User"].Visible = false;

            // Thêm cột nút Sửa
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.Name = "EditColumn";
            btnEdit.HeaderText = "";
            btnEdit.Text = "Sửa";
            btnEdit.UseColumnTextForButtonValue = true;

            // Tùy chỉnh kiểu hiển thị của nút
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.DefaultCellStyle.BackColor = Color.LightYellow;
            btnEdit.DefaultCellStyle.Font = new Font(dgvBookings.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            btnEdit.DefaultCellStyle.Padding = new Padding(2);
            dgvBookings.Columns.Add(btnEdit);
            dgvBookings.Columns["EditColumn"].Width = 60;
            dgvBookings.Columns["EditColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            // Thêm cột nút Xóa
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "DeleteColumn";
            btnDelete.HeaderText = "";
            btnDelete.Text = "Xóa";
            btnDelete.UseColumnTextForButtonValue = true;

            // Tùy chỉnh kiểu hiển thị của nút
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.DefaultCellStyle.BackColor = Color.IndianRed;
            btnDelete.DefaultCellStyle.Font = new Font(dgvBookings.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            btnDelete.DefaultCellStyle.Padding = new Padding(2);

            dgvBookings.Columns.Add(btnDelete);
            dgvBookings.Columns["DeleteColumn"].Width = 60;
            dgvBookings.Columns["DeleteColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvBookings.ReadOnly = true;
            dgvBookings.AllowUserToAddRows = false;

            // Tự động điều chỉnh độ rộng dựa trên nội dung và tiêu đề
            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Đặt kiểu chữ cho tiêu đề cột
            dgvBookings.ColumnHeadersDefaultCellStyle.Font = new Font(dgvBookings.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

            // Chọn cả hàng
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Không cho chọn nhiều hàng
            dgvBookings.MultiSelect = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var addForm = _serviceProvider.GetRequiredService<AddBookingForm>())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh your fields list here
                    LoadBookings();
                }
            }
        }

        private void dgvFields_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header row
            if (e.ColumnIndex < 0) return; // Ignore header column

            // Ignore other columns
            if (dgvBookings.Columns[e.ColumnIndex].Name != "EditColumn"
                && dgvBookings.Columns[e.ColumnIndex].Name != "DeleteColumn")
                return;

            var booking = (dynamic)dgvBookings.CurrentRow.DataBoundItem;
            var bookingId = booking.BookingId;


            if (dgvBookings.Columns[e.ColumnIndex].Name == "EditColumn")
            {
                using (var editForm = _serviceProvider.GetRequiredService<AddBookingForm>())
                {
                    editForm.EditingBooking = _bookingController.GetBookingById(bookingId);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadBookings();
                    }
                }
            }
            if (dgvBookings.Columns[e.ColumnIndex].Name == "DeleteColumn")
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa đơn này không?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _bookingController.DeleteBooking(bookingId);
                    LoadBookings();
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
            var bookings = _bookingController.GetAllBookings()
                .Where(b =>
                    b.BookingId.ToString().Contains(keyword)
                    //b.Customer.CustomerName.ToLower().Contains(keyword)
                );

            bindingSourceBooking.DataSource = bookings.ToList();
            dgvBookings.DataSource = bindingSourceBooking;
        }

        //private void btnExport_Click(object sender, EventArgs e)
        //{
        //    ExportToCsv();
        //}

        //private void ExportToCsv()
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
        //    saveFileDialog.Title = "Xuất file danh sách Sân";
        //    saveFileDialog.FileName = "Fields";

        //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        var fields = _fieldController.GetAllFields();

        //        var lines = new List<string>();
        //        lines.Add("FieldId;FieldName;FieldType;PricePerHour;Status");

        //        foreach (var f in fields)
        //        {
        //            lines.Add($"{f.FieldId};{f.FieldName};{f.FieldType};{f.PricePerHour};{f.Status}");
        //        }

        //        File.WriteAllLines(saveFileDialog.FileName, lines, new UTF8Encoding(true));
        //        MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
    }
}
