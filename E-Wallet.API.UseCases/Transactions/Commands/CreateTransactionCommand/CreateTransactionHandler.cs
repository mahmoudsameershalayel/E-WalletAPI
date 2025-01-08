using AutoMapper;
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

namespace E_Wallet.API.UseCases.Transactions.Commands.CreateTransactionCommand
{
    public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, BaseResponse<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CreateTransactionHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<BaseResponse<bool>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var transaction = _mapper.Map<Data.DBEntities.Transaction>(request);
                _repositoryManager.TransactionRepository.CreateTransaction(transaction);
                await _repositoryManager.SaveAsync();
                switch (request.TransactionType)
                {
                    case (TransactionType.Transfer):
                        var wallet = await _repositoryManager.WalletRepository.GetWalletByIdAsync(request.WalletId);
                        var recipientWallet = await _repositoryManager.WalletRepository.GetWalletByIdAsync(request.RecipientWalletId);
                        if (wallet.Balance < request.Amount)
                        {
                            response.Message = "The Balance in your wallet not enough to make transaction!!";
                        }
                        else if (!wallet.Currency.Equals(recipientWallet.Currency)) {
                            response.Message = "The Currency of two wallets not same!!";
                        }
                        else
                        {
                            wallet.Balance -= request.Amount;
                            recipientWallet.Balance += request.Amount;
                            _repositoryManager.WalletRepository.UpdateWallet(wallet);
                            _repositoryManager.WalletRepository.UpdateWallet(recipientWallet);
                            await _repositoryManager.SaveAsync();
                            response.IsSuccess = true;
                            response.Data = true;
                            response.Message = "The Transfer operation completed successfullt";
                        }
                        break;
                    case (TransactionType.Payment):
                        var wallet1 = await _repositoryManager.WalletRepository.GetWalletByIdAsync(request.WalletId);
                        if (wallet1.Balance < request.Amount)
                        {
                            response.Message = "The Balance in your wallet not enough to make transaction!!";
                        }
                        else
                        {
                            wallet1.Balance -= request.Amount;
                            _repositoryManager.WalletRepository.UpdateWallet(wallet1);
                            await _repositoryManager.SaveAsync();
                            response.IsSuccess = true;
                            response.Data = true;
                            response.Message = "The Payment operation completed successfullt";
                        }
                        break;
                    case (TransactionType.Recharge):
                        var recipientWallet1 = await _repositoryManager.WalletRepository.GetWalletByIdAsync(request.RecipientWalletId);
                        recipientWallet1.Balance += request.Amount;
                        _repositoryManager.WalletRepository.UpdateWallet(recipientWallet1);
                        await _repositoryManager.SaveAsync();
                        response.IsSuccess = true;
                        response.Data = true;
                        response.Message = "The Recharge operation completed successfullt";
                        break;
                }

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
    }
}
