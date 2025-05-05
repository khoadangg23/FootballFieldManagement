using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballFieldManagement.Models;
using FootballFieldManagement.Repositories.Interfaces;

namespace FootballFieldManagement.Repositories.Implementations
{
    public class BookingDetailRepository : IBookingDetailRepository
    {
        private readonly FootballFieldManagementDbContext _context;
        public BookingDetailRepository(FootballFieldManagementDbContext context)
        {
            _context = context;
        }
        public IEnumerable<BookingDetail> GetAll()
        {
            return _context.BookingDetails.ToList();
        }
        public BookingDetail GetById(int id)
        {
            return _context.BookingDetails.Find(id);
        }
        public void Add(BookingDetail bookingDetail)
        {
            _context.BookingDetails.Add(bookingDetail);
            _context.SaveChanges();
        }
        public void Update(BookingDetail bookingDetail)
        {
            _context.BookingDetails.Update(bookingDetail);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var bookingDetail = _context.BookingDetails.Find(id);
            if (bookingDetail != null)
            {
                _context.BookingDetails.Remove(bookingDetail);
                _context.SaveChanges();
            }
        }
    }
}
