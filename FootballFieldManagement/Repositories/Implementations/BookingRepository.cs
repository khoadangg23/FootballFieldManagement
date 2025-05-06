using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballFieldManagement.Models;
using FootballFieldManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FootballFieldManagement.Repositories.Implementations
{
    public class BookingRepository : IBookingRepository
    {
        private readonly FootballFieldManagementDbContext _context;
        public BookingRepository(FootballFieldManagementDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Booking> GetAll()
        {
            return _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.User)
                .Include(b => b.BookingDetails)
                    .ThenInclude(d => d.Field)
                .ToList();
        }
        public Booking GetById(int id)
        {
            return _context.Bookings.Find(id);
        }
        public void Add(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }
        public void Update(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }
    }
}
