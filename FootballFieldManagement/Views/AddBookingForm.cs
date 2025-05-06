using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FootballFieldManagement.Models;
using FootballFieldManagement.Services.Interfaces;

namespace FootballFieldManagement.Views
{
    public partial class AddBookingForm : Form
    {
        private readonly ICustomerService _customerService;
        private readonly IFieldService _fieldService;
        private readonly IBookingService _bookingService;
        private readonly ISessionService _sessionService;
        private readonly IBookingDetailService _bookingDetailService;
        private Field _selectedField;
        private DateTime _selectedDate;
        private List<int> _selectedHours = new List<int>();
        private List<int> _pastHours = new List<int>();
        private List<int> _bookedHours = new List<int>();
        private List<string> _statusOptions = new List<string> { "Chưa thanh toán", "Đã đặt cọc", "Đã thanh toán" };
        public Booking EditingBooking { get; set; }

        public AddBookingForm(IBookingDetailService bookingDetailService, ICustomerService customerService, IFieldService fieldService, IBookingService bookingService, ISessionService sessionService)
        {
            InitializeComponent();

            _customerService = customerService;
            _fieldService = fieldService;
            _bookingService = bookingService;
            _sessionService = sessionService;
            _bookingDetailService = bookingDetailService;

            this.StartPosition = FormStartPosition.CenterScreen;

            dtpBookingDate.Format = DateTimePickerFormat.Short;
            dtpBookingDate.ShowUpDown = false;

            this.Load += AddBookingForm_Load; // Load dữ liệu ban đầu khi Form mở
            cmbCustomerName.SelectedIndexChanged += cmbCustomerName_SelectedIndexChanged; // Khi chọn khách hàng khác
            cmbFieldType.SelectedIndexChanged += cmbFieldType_SelectedIndexChanged; // Khi chọn loại sân khác
            cmbFieldName.SelectedIndexChanged += cmbFieldName_SelectedIndexChanged; // Khi chọn sân khác
            dtpBookingDate.ValueChanged += dtpBookingDate_ValueChanged; // Khi chọn ngày khác
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void AddBookingForm_Load(object sender, EventArgs e)
        {
            SetupCustomer();
            SetupFieldType(); // Tải danh sách sân bóng vào ComboBox

            _pastHours = Enumerable.Range(0, DateTime.Now.Hour).ToList();
            cmbStatus.DataSource = _statusOptions;
            dtpBookingDate.Value = DateTime.Today;
            dtpBookingDate.MinDate = DateTime.Today; // Ngày tối thiểu là hôm nay
            LoadHourButtons(); // Tải các nút giờ vào TableLayoutPanel

            lblShowUserCreated.Text = _sessionService.GetCurrentUser().FullName;
            lblShowDateCreated.Text = DateTime.Now.Date.ToString("d");

            _selectedField = (Field)cmbFieldName.SelectedItem;
            _selectedDate = dtpBookingDate.Value.Date;

            if (EditingBooking != null)
            {
                // Chế độ Edit → nạp dữ liệu lên form
                cmbCustomerName.SelectedItem = _customerService.GetCustomerById(EditingBooking.CustomerId);
                dtpBookingDate.Value = EditingBooking.BookingDate.ToDateTime(TimeOnly.MinValue);
                cmbStatus.SelectedItem = EditingBooking.Status;

                // Load các booking details
                // ...
            }
        }

        private void SetupCustomer()
        {
            var customers = _customerService.GetAllCustomers();
            cmbCustomerName.DataSource = customers.ToList();
            cmbCustomerName.DisplayMember = "CustomerName"; // Tên hiển thị trong ComboBox
            cmbCustomerName.ValueMember = "CustomerId"; // Giá trị thực tế của khách hàng
        }

        private void SetupFieldType()
        {
            var fields = _fieldService.GetAllFields();
            cmbFieldType.DataSource = fields.Select(f => f.FieldType)
                                            .Distinct()
                                            .ToList(); // Lấy danh sách loại sân bóng duy nhất
            cmbFieldType.DisplayMember = "FieldType"; // Tên hiển thị trong ComboBox
            //cmbFieldType.ValueMember = "FieldId"; // Giá trị thực tế của sân bóng
        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy khách hàng đang chọn
            if (cmbCustomerName.SelectedItem != null)
            {
                txtCustomerPhone.Text = ((Customer)cmbCustomerName.SelectedItem).PhoneNumber;
            }
        }

        private void cmbFieldType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy sân bóng đang chọn
            if (cmbFieldType.SelectedItem != null)
            {
                string typeField = (string)cmbFieldType.SelectedItem; // Lấy loại sân bóng đã chọn

                var fields = _fieldService.GetAllFields();
                cmbFieldName.DataSource = fields
                    .Where(f => f.Status != "Bảo trì") // Lọc sân còn trống
                    .Where(f => f.FieldType == typeField)
                    .ToList(); // Lấy danh sách loại sân bóng duy nhất
                cmbFieldName.DisplayMember = "FieldName"; // Tên hiển thị trong ComboBox
                cmbFieldName.ValueMember = "FieldId";

                lblShowPricePerHour.Text = ((Field)cmbFieldName.SelectedItem).PricePerHour.ToString(); // Hiển thị giá sân
            }
        }

        private void cmbFieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy sân bóng đang chọn
            if (cmbFieldName.SelectedItem != null)
            {
                _selectedField = (Field)cmbFieldName.SelectedItem; // Lấy đối tượng Field đã chọn
                
                LoadHourButtons();
            }
        }

        private void dtpBookingDate_ValueChanged(object sender, EventArgs e)
        {
            _selectedDate = dtpBookingDate.Value.Date; // Chỉ lấy phần ngày
            if (_selectedDate < DateTime.Today)
            {
                MessageBox.Show("Ngày đặt sân không được nhỏ hơn ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpBookingDate.Value = DateTime.Today; // Đặt lại ngày về hôm nay
                return;
            }
            // Nếu ngày đã chọn là hôm nay, lấy giờ hiện tại
            if (_selectedDate == DateTime.Today)
            {
                // Lấy giờ hiện tại
                int currentHour = DateTime.Now.Hour;
                // Lấy danh sách giờ đã đặt từ giờ hiện tại trở đi
                _pastHours = Enumerable.Range(0, currentHour).ToList();
            }
            else
            {
                // Nếu không phải hôm nay, không có giờ quá khứ
                _pastHours = new List<int>();
            }
            LoadHourButtons();
        }

        private void LoadHourButtons()
        {
            _bookedHours = GetBookedHours(); // Lấy danh sách giờ đã đặt cho sân và ngày đã chọn

            // Thiết lập số giờ tối đa trong ngày (từ 6h đến 22h)
            int totalHours = 16;
            int columns = panelHours.ColumnCount;

            // Xóa các controls cũ (nếu có)
            panelHours.Controls.Clear();

            for (int i = 0; i < totalHours; i++)
            {
                int realHour = i + 6;
                Button btnHour = new Button();
                btnHour.Text = realHour.ToString();
                btnHour.Name = "btnHour_" + realHour.ToString();
                btnHour.Dock = DockStyle.Fill;
                btnHour.Margin = new Padding(2);
                btnHour.Tag = realHour; // Lưu giá trị giờ vào Tag

                // Thiết lập màu ban đầu dựa trên trạng thái đã chọn (nếu có)
                if (_pastHours.Contains(realHour))
                {
                    btnHour.BackColor = Color.LightGray; // Màu xám cho giờ quá khứ
                    btnHour.Enabled = false; // Không cho click vào giờ quá khứ
                }
                else if (_bookedHours.Contains(realHour))
                {
                    btnHour.BackColor = Color.Salmon; // Màu đỏ nhạt cho giờ đã đặt
                    btnHour.Enabled = false; // Không cho click vào giờ đã đặt
                }
                else
                {
                    btnHour.BackColor = Color.LightGreen; // Màu xanh lá cho giờ trống
                    btnHour.Enabled = true; // Cho phép click để đặt
                    //btnHour.Click += btnKhungGio_Click; // Đăng ký sự kiện click cho giờ trống
                }

                // Thêm sự kiện click
                btnHour.Click += BtnHour_Click;

                // Tính toán vị trí cột và hàng
                int column = i % columns;
                int row = i / columns;

                // Thêm nút vào TableLayoutPanel
                panelHours.Controls.Add(btnHour, column, row);
            }
        }

        private void BtnHour_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                int hour = (int)clickedButton.Tag; // Lấy giờ từ Tag

                if (_selectedHours.Contains(hour))
                {
                    // Nếu giờ đã được chọn, bỏ chọn và đổi màu lại mặc định
                    _selectedHours.Remove(hour);
                    clickedButton.BackColor = Color.LightGreen;
                }
                else
                {
                    // Nếu giờ chưa được chọn, chọn nó và đổi màu
                    _selectedHours.Add(hour);
                    clickedButton.BackColor = Color.Yellow;
                }

                 //Tùy chọn: Sắp xếp lại danh sách giờ đã chọn nếu cần
                 _selectedHours.Sort();

                lblShowHoursNumber.Text = _selectedHours.Count.ToString();

                lblShowTotal.Text = _selectedHours.Count * decimal.Parse(lblShowPricePerHour.Text) + "";

                // Tùy chọn: Hiển thị danh sách giờ đã chọn (để kiểm tra)
                //MessageBox.Show("Các giờ đã chọn: " + string.Join(", ", _selectedHours));
            }
        }

        private List<int> GetBookedHours()
        {
            // Lấy danh sách giờ đã đặt cho sân và ngày đã chọn
            var bookings = _bookingService.GetBookingsByFieldAndDate(_selectedField.FieldId, _selectedDate);
            List<int> bookedHours = new List<int>();
            foreach (var booking in bookings)
            {
                foreach (var detail in booking.BookingDetails)
                {
                    for (int i = 0; i < detail.DurationHours; i++)
                    {
                        bookedHours.Add(detail.StartTime.Hour + i);
                    }
                }
            }
            return bookedHours;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedHours.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một khung giờ để đặt sân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int hourStart = _selectedHours.First();
            int hourEnd = _selectedHours.Last() + 1;

            // Tạo Booking
            Booking booking = new Booking
            {
                CustomerId = ((Customer)cmbCustomerName.SelectedItem).CustomerId,
                BookingDate = DateOnly.FromDateTime(_selectedDate),
                TotalAmount = decimal.Parse(lblShowTotal.Text),
                Status = cmbStatus.SelectedItem.ToString(),
                CreatedDate = DateTime.Now,
                UserId = _sessionService.GetCurrentUser().UserId
            };
            int newBookingId = _bookingService.AddBooking(booking);

            // Tạo BookingDetail
            BookingDetail bookingDetail = new BookingDetail
            {
                BookingId = newBookingId,
                FieldId = _selectedField.FieldId,
                StartTime = new DateTime(_selectedDate.Year, _selectedDate.Month, _selectedDate.Day, hourStart, 0, 0),
                EndTime = new DateTime(_selectedDate.Year, _selectedDate.Month, _selectedDate.Day, hourEnd, 0, 0),
                DurationHours = int.Parse(lblShowHoursNumber.Text),
                PriceApplied = decimal.Parse(lblShowPricePerHour.Text)
            };
            _bookingDetailService.AddBookingDetail(bookingDetail);
            MessageBox.Show("Đặt sân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
