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
    public class CheckUserWalletHandler : IRequestHandler<CheckUserWalletQuery, bool>
    {
        private readonly IRepositoryManager _repositoryManager;
        public CheckUserWalletHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<bool> Handle(CheckUserWalletQuery request, CancellationToken cancellationToken)
        {
            var response = false;
            var wallets = await _repositoryManager.WalletRepository.GetWalletsByApplicationUserId(request.ApplicationUserId);
            if (wallets.Any(w => w.Id == request.WalletId))
            {
                response = true;
            }
            return response;
        }
    }
}