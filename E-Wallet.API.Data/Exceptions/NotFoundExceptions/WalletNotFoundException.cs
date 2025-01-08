using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Data.Exceptions.NotFoundExceptions
{
    public class WalletNotFoundException : NotFoundException
    {
        public WalletNotFoundException(int id) : base($"The Wallet with id : {id} doesn't exist in the database.")
        {
        }
        public WalletNotFoundException(int id , bool isCustomer) : base($"The Customer with id : {id} doesn't have any wallet in the database.")
        {
        }
    }
}
