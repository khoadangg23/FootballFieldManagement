using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballFieldManagement.Models;

namespace FootballFieldManagement.Repositories.Interfaces
{
    public interface IBookingDetailRepository
    {
        IEnumerable<BookingDetail> GetAll();
        BookingDetail GetById(int id);
        void Add(BookingDetail bookingDetail);
        void Update(BookingDetail bookingDetail);
        void Delete(int id);
    }
}
