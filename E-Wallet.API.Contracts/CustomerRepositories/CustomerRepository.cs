using E_Wallet.API.Data;
using E_Wallet.API.Data.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Contracts.CustomerRepositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void CreateCustomer(Customer customer) => Create(customer);

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync() => await FindAll().ToListAsync();

    }
}
