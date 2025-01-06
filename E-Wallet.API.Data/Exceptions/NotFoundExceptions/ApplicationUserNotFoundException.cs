using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Data.Exceptions.NotFoundExceptions
{
    public class ApplicationUserNotFoundException : NotFoundException
    {
        public ApplicationUserNotFoundException(string id) : base($"The user with id: {id} doesn't exist in the database.")
        {
        }
        public ApplicationUserNotFoundException(int id) : base($"The customer with id: {id} doesn't exist in the database.")
        {
        }
    }
}
