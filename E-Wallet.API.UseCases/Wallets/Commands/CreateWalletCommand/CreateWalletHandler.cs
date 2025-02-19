﻿using AutoMapper;
using E_Wallet.API.Contracts;
using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.Data.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace E_Wallet.API.UseCases.Wallets.Commands.CreateWalletCommand
{
    public class CreateWalletHandler : IRequestHandler<CreateWalletCommand, BaseResponse<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CreateWalletHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<BaseResponse<bool>> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var wallet = _mapper.Map<Wallet>(request);
                var user = await _repositoryManager.ApplicationUser.GetApplicationUser(request.ApplicationUserId);
                switch (user.userType)
                {
                    case UserType.Customer:
                        wallet.WalletType = WalletType.WalletForCustomer;
                        break;
                    case UserType.RechargePoint:
                        wallet.WalletType = WalletType.WalletForRechargePoint;
                        break;
                    case UserType.PaymentService:
                        wallet.WalletType = WalletType.WalletForPaymentService;
                        break;
                }
                wallet.ApplicationUserId = request.ApplicationUserId;
                _repositoryManager.WalletRepository.CreateWallet(wallet);
                await _repositoryManager.SaveAsync();
                response.Data = true;
                response.IsSuccess = true;
                response.Message = "The Wallet Created Successfully";
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
    }
}
