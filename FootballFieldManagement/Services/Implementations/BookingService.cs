using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballFieldManagement.Models;
using FootballFieldManagement.Repositories.Interfaces;
using FootballFieldManagement.Services.Interfaces;

namespace FootballFieldManagement.Services.Implementations
{
    internal class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public IEnumerable<Booking> GetAllBookings()
        {
            return _bookingRepository.GetAll();
        }
        public Booking GetBookingById(int id)
        {
            return _bookingRepository.GetById(id);
        }
        public void AddBooking(Booking booking)
        {
            _bookingRepository.Add(booking);
        }
        public void UpdateBooking(Booking booking)
        {
            _bookingRepository.Update(booking);
        }
        public void DeleteBooking(int id)
        {
            _bookingRepository.Delete(id);
        }
    }
}
