using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballFieldManagement.Models;

namespace FootballFieldManagement.Services.Interfaces
{
    public interface IBookingDetailService
    {
        IEnumerable<BookingDetail> GetAllBookingDetails();
        BookingDetail GetBookingDetailById(int id);
        void AddBookingDetail(BookingDetail bookingDetail);
        void UpdateBookingDetail(BookingDetail bookingDetail);
        void DeleteBookingDetail(int id);
    }
}
