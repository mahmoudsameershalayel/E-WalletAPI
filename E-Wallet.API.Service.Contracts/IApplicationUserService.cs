﻿using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.UseCases.DTOs.ApplicationUserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Service.Contracts
{
    public interface IApplicationUserService
    {
        Task<IEnumerable<ApplicationUserDto>> GetAllCustomersAsync();
        Task<IEnumerable<Customer>> GetAllCustomersWithAsync();
        Task<Customer> GetCustomerByApplicationUserId(string userId);
        Task<ApplicationUser> GetUserByName(string username);
        Task<ApplicationUserDto> GetUserByEmail(string email);
    }
}
