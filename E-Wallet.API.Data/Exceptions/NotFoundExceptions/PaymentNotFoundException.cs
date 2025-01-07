using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Data.Exceptions.NotFoundExceptions
{
    public class PaymentNotFoundException : NotFoundException
    {
        public PaymentNotFoundException(int id) : base($"The Payment Service with id : {id} doesn't exist in the database.")
        {
        }
    }
}
