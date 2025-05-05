using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballFieldManagement.Models;
using FootballFieldManagement.Services.Interfaces;

namespace FootballFieldManagement.Controllers
{
    public class PaymentController
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public IEnumerable<Payment> GetAllPayments()
        {
            return _paymentService.GetAllPayments();
        }

        public Payment GetPaymentById(int id)
        {
            return _paymentService.GetPaymentById(id);
        }

        public void AddPayment(Payment payment)
        {
            _paymentService.AddPayment(payment);
        }

        public void UpdatePayment(Payment payment)
        {
            _paymentService.UpdatePayment(payment);
        }

        public void DeletePayment(int id)
        {
            _paymentService.DeletePayment(id);
        }
    }
}
