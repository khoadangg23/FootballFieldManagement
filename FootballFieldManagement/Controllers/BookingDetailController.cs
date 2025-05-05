using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballFieldManagement.Models;
using FootballFieldManagement.Services.Interfaces;

namespace FootballFieldManagement.Controllers
{
    public class BookingDetailController
    {
        private readonly IBookingDetailService _bookingDetailService;

        public BookingDetailController(IBookingDetailService bookingDetailService)
        {
            _bookingDetailService = bookingDetailService;
        }

        public IEnumerable<BookingDetail> GetAllBookingDetails()
        {
            return _bookingDetailService.GetAllBookingDetails();
        }

        public BookingDetail GetBookingDetailById(int id)
        {
            return _bookingDetailService.GetBookingDetailById(id);
        }

        public void AddBookingDetail(BookingDetail bookingDetail)
        {
            _bookingDetailService.AddBookingDetail(bookingDetail);
        }

        public void UpdateBookingDetail(BookingDetail bookingDetail)
        {
            _bookingDetailService.UpdateBookingDetail(bookingDetail);
        }

        public void DeleteBookingDetail(int id)
        {
            _bookingDetailService.DeleteBookingDetail(id);
        }
    }
}
