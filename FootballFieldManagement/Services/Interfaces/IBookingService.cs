using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballFieldManagement.Models;

namespace FootballFieldManagement.Services.Interfaces
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetAllBookings();
        Booking GetBookingById(int id);
        int AddBooking(Booking booking);
        void UpdateBooking(Booking booking);
        void DeleteBooking(int id);

        IEnumerable<Booking> GetBookingsByFieldAndDate(int fieldId, DateTime date);
    }
}
