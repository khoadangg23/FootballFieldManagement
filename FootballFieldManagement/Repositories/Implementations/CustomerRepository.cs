using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballFieldManagement.Models;
using FootballFieldManagement.Repositories.Interfaces;

namespace FootballFieldManagement.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FootballFieldManagementDbContext _context;
        public CustomerRepository(FootballFieldManagementDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }
        public Customer GetById(int id)
        {
            return _context.Customers.Find(id);
        }
        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }
    }
}
