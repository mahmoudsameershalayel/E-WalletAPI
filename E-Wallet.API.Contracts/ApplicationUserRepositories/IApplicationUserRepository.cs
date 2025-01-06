using E_Wallet.API.Data.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Contracts.ApplicationUserRepositories
{
    public interface IApplicationUserRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Customer> GetCustomerByApplicationUserId(string userId);
    }
}
