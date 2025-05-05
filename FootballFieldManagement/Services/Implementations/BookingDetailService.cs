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
    internal class BookingDetailService : IBookingDetailService
    {
        private readonly IBookingDetailRepository _bookingDetailRepository;
        public BookingDetailService(IBookingDetailRepository bookingDetailRepository)
        {
            _bookingDetailRepository = bookingDetailRepository;
        }
        public IEnumerable<BookingDetail> GetAllBookingDetails()
        {
            return _bookingDetailRepository.GetAll();
        }
        public BookingDetail GetBookingDetailById(int id)
        {
            return _bookingDetailRepository.GetById(id);
        }
        public void AddBookingDetail(BookingDetail bookingDetail)
        {
            _bookingDetailRepository.Add(bookingDetail);
        }
        public void UpdateBookingDetail(BookingDetail bookingDetail)
        {
            _bookingDetailRepository.Update(bookingDetail);
        }
        public void DeleteBookingDetail(int id)
        {
            _bookingDetailRepository.Delete(id);
        }
    }
}
