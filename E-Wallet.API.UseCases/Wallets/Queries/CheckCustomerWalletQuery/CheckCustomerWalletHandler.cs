using AutoMapper;
using E_Wallet.API.Contracts;
using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.Data.Exceptions.NotFoundExceptions;
using E_Wallet.API.UseCases.DTOs.WalletDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Wallets.Queries.CheckCustomerWalletQuery
{
    public class CheckCustomerWalletHandler : IRequestHandler<CheckCustomerWalletQuery, bool>
    {
        private readonly IRepositoryManager _repositoryManager;
        public CheckCustomerWalletHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<bool> Handle(CheckCustomerWalletQuery request, CancellationToken cancellationToken)
        {
            var response = false;
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.ApplicationUserId);
            if (customer is null) throw new ApplicationUserNotFoundException(request.ApplicationUserId);
            var wallets = await _repositoryManager.WalletRepository.GetWalletByCustomerId(customer.Id);
            if (wallets.Any(w => w.Id == request.WalletId))
            {
                response = true;
            }
            return response;
        }
    }
}