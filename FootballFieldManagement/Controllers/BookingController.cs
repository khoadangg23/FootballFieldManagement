using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballFieldManagement.Models;
using FootballFieldManagement.Services.Interfaces;

namespace FootballFieldManagement.Controllers
{
    public class BookingController
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _bookingService.GetAllBookings();
        }

        public Booking GetBookingById(int id)
        {
            return _bookingService.GetBookingById(id);
        }

        public void AddBooking(Booking booking)
        {
            _bookingService.AddBooking(booking);
        }

        public void UpdateBooking(Booking booking)
        {
            _bookingService.UpdateBooking(booking);
        }

        public void DeleteBooking(int id)
        {
            _bookingService.DeleteBooking(id);
        }
    }
}
