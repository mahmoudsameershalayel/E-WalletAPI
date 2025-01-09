using AutoMapper;
using E_Wallet.API.Contracts;
using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.Data.Exceptions.NotFoundExceptions;
using E_Wallet.API.Service.Contracts;
using E_Wallet.API.UseCases.DTOs.ApplicationUserDTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Service
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public ApplicationUserService(IRepositoryManager repositoryManager, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
            _userManager = userManager;
        }

        public Task<IEnumerable<ApplicationUserDto>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllCustomersWithAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByApplicationUserId(string userId)
        {
            throw new NotImplementedException();
        }

       

       

        public Task<ApplicationUserDto> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> GetUserByName(string username)
        {
            try
            {
                return await _userManager.FindByNameAsync(username);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

       
    }
}
