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
                var wallet = await _repositoryManager.WalletRepository.GetWalletByIdAsync(request.WalletId);
                var recipientWallet = await _repositoryManager.WalletRepository.GetWalletByIdAsync(request.RecipientWalletId);
                if (wallet.Balance < request.Amount)
                {
                    response.Message = "The Balance not enough to make transaction!!";
                }
                else if (!wallet.Currency.Equals(recipientWallet.Currency))
                {
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
                    response.Message = "The Transaction operation completed successfullt";
                }
                /* switch (request.TransactionType)
                 {
                     case (TransactionType.Transfer):
                         var wallet = await _repositoryManager.WalletRepository.GetWalletByIdAsync(request.WalletId);
                         var recipientWallet = await _repositoryManager.WalletRepository.GetWalletByIdAsync(request.RecipientWalletId);
                         if (wallet.Balance < request.Amount)
                         {
                             response.Message = "The Balance in your wallet not enough to make transaction!!";
                         }
                         else if (!wallet.Currency.Equals(recipientWallet.Currency))
                         {
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
                         var wallet2 = await _repositoryManager.WalletRepository.GetWalletByIdAsync(request.WalletId);
                         var recipientWallet2 = await _repositoryManager.WalletRepository.GetWalletByIdAsync(request.RecipientWalletId);
                         if (wallet2.Balance < request.Amount)
                         {
                             response.Message = "The Balance in your wallet not enough to make transaction!!";
                         }
                         else if (!wallet2.Currency.Equals(recipientWallet2.Currency))
                         {
                             response.Message = "The Currency of two wallets not same!!";
                         }
                         else
                         {
                             wallet2.Balance -= request.Amount;
                             recipientWallet2.Balance += request.Amount;
                             _repositoryManager.WalletRepository.UpdateWallet(wallet2);
                             _repositoryManager.WalletRepository.UpdateWallet(recipientWallet2);
                             await _repositoryManager.SaveAsync();
                             response.IsSuccess = true;
                             response.Data = true;
                             response.Message = "The Payment operation completed successfullt";
                         }
                         break;
                     case (TransactionType.Recharge):
                         var wallet3 = await _repositoryManager.WalletRepository.GetWalletByIdAsync(request.WalletId);
                         var recipientWallet3 = await _repositoryManager.WalletRepository.GetWalletByIdAsync(request.RecipientWalletId);
                         wallet3.Balance -= request.Amount; ;
                         recipientWallet3.Balance += request.Amount;
                         _repositoryManager.WalletRepository.UpdateWallet(wallet3);
                         _repositoryManager.WalletRepository.UpdateWallet(recipientWallet3);
                         await _repositoryManager.SaveAsync();
                         response.IsSuccess = true;
                         response.Data = true;
                         response.Message = "The Recharge operation completed successfullt";
                         break;
                 }  */

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
    }
}
