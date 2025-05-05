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
    internal class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public IEnumerable<Payment> GetAllPayments()
        {
            return _paymentRepository.GetAll();
        }
        public Payment GetPaymentById(int id)
        {
            return _paymentRepository.GetById(id);
        }
        public void AddPayment(Payment payment)
        {
            _paymentRepository.Add(payment);
        }
        public void UpdatePayment(Payment payment)
        {
            _paymentRepository.Update(payment);
        }
        public void DeletePayment(int id)
        {
            _paymentRepository.Delete(id);
        }
    }
}
