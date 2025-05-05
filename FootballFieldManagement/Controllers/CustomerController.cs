using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballFieldManagement.Models;
using FootballFieldManagement.Services.Interfaces;

namespace FootballFieldManagement.Controllers
{
    public class CustomerController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerService.GetAllCustomers();
        }
        public Customer GetCustomerById(int id)
        {
            return _customerService.GetCustomerById(id);
        }
        public void AddCustomer(Customer customer)
        {
            _customerService.AddCustomer(customer);
        }
        public void UpdateCustomer(Customer customer)
        {
            _customerService.UpdateCustomer(customer);
        }
        public void DeleteCustomer(int id)
        {
            _customerService.DeleteCustomer(id);
        }
    }
}
