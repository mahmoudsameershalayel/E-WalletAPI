using AutoMapper;
using E_Wallet.API.Contracts;
using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.Data.Exceptions.NotFoundExceptions;
using E_Wallet.API.Infrastructure.DTOs.ApplicationUserDTOs;
using E_Wallet.API.Service.Contracts;
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



        public async Task<IEnumerable<ApplicationUserDto>> GetAllCustomersAsync()
        {
            var users = await _repositoryManager.ApplicationUser.GetAllCustomersAsync();
            return _mapper.Map<IEnumerable<ApplicationUserDto>>(users);
        }
        public async Task<IEnumerable<Customer>> GetAllCustomersWithAsync()
        {
            var users = await _repositoryManager.ApplicationUser.GetAllCustomersAsync();
            return users;
        }
        public async Task<Customer> GetCustomerByApplicationUserId(string userId)
        {
            var customers = await _repositoryManager.ApplicationUser.GetAllCustomersAsync();
            foreach (Customer cust in customers)
            {
                if (cust.ApplicationUserId.Equals(userId))
                {
                    return cust;
                }
            }
            throw new ApplicationUserNotFoundException(userId);
        }

        public async Task<ApplicationUserDto> GetCustomerById(int customerId)
        {
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByIdAsync(customerId);
            if (customer is null)
            {
                throw new ApplicationUserNotFoundException(customerId);
            }
            return _mapper.Map<ApplicationUserDto>(customer);

        }

        public async Task<IEnumerable<Customer>> GetCustomersByIds(List<int> customerIds)
        {
            var customers = new List<Customer>();
            foreach (var customerId in customerIds)
            {
                var customer = await _repositoryManager.ApplicationUser.GetCustomerByIdAsync(customerId);
                if (customer is null)
                {
                    throw new ApplicationUserNotFoundException(customerId);
                }
                customers.Add(customer);
            }

            return customers;

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

        public async Task UpdateCustomer(int customerId, UpdateCustomerDto dto)
        {
            try
            {

                var customer = await _repositoryManager.ApplicationUser.GetCustomerByIdAsync(customerId);
                _mapper.Map(dto, customer);
                await _repositoryManager.SaveAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
