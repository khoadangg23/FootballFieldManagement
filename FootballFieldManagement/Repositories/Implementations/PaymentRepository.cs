using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballFieldManagement.Models;
using FootballFieldManagement.Repositories.Interfaces;

namespace FootballFieldManagement.Repositories.Implementations
{
    internal class PaymentRepository : IPaymentRepository
    {
        private readonly FootballFieldManagementDbContext _context;
        public PaymentRepository(FootballFieldManagementDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Payment> GetAll()
        {
            return _context.Payments.ToList();
        }
        public Payment GetById(int id)
        {
            return _context.Payments.Find(id);
        }
        public void Add(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }
        public void Update(Payment payment)
        {
            _context.Payments.Update(payment);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var payment = _context.Payments.Find(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                _context.SaveChanges();
            }
        }
    }
}
