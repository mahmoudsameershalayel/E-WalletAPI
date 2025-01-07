using E_Wallet.API.Data;
using E_Wallet.API.Data.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Contracts.PaymentRepositories
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationDbContext context) : base(context)
        {
            
        }
        public void CreatePayment(Payment payment) => Create(payment);
       

        public void DeletePayment(Payment payment) => Delete(payment);


        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync() => await FindAll().ToListAsync();


        public async Task<Payment> GetPaymentByIdAsync(int id) =>await  FindByCondition(x => x.Id == id).FirstOrDefaultAsync();


        public void UpdatePayment(Payment payment) => Update(payment);

    }
}
