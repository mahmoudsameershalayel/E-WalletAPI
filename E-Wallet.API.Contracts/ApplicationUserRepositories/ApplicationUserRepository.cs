﻿using E_Wallet.API.Data;
using E_Wallet.API.Data.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Contracts.ApplicationUserRepositories
{
    public class ApplicationUserRepository : RepositoryBase<Customer>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync() => await FindAll().Include(c => c.ApplicationUser).ToListAsync();
        public async Task<Customer> GetCustomerByIdAsync(int id) => await FindByCondition(x => x.Id == id).Include(x => x.ApplicationUser).SingleOrDefaultAsync();
        public async Task<Customer> GetCustomerByApplicationUserId(string userId) =>await FindByCondition(x => x.ApplicationUser.Id.Equals(userId)).Include(x => x.ApplicationUser).FirstOrDefaultAsync();
        public void UpdateCustomer(Customer customer) => Update(customer);

        public void CreateCustomer(Customer customer)
        {
            Create(customer);
        }


    }
}
