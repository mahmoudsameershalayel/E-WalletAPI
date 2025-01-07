using E_Wallet.API.Data.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Contracts.PaymentRepositories
{
    public interface IPaymentRepository                                                 
    {
        public Task<IEnumerable<Payment>> GetAllPaymentsAsync();
        public Task<Payment> GetPaymentByIdAsync(int id);
        public void CreatePayment(Payment payment);
        public void UpdatePayment(Payment payment);
        public void DeletePayment(Payment payment);
    }
}
