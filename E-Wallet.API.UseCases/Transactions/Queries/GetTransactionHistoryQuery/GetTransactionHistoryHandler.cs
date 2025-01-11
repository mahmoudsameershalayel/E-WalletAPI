using AutoMapper;
using E_Wallet.API.Contracts;
using E_Wallet.API.UseCases.DTOs.RechargePointDTOs;
using E_Wallet.API.UseCases.DTOs.TransactionDTOs;
using E_Wallet.API.UseCases.DTOs.WalletDTOs;
using E_Wallet.API.UseCases.RechargePoints.Queries.GetAllRechargePointsQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Transactions.Queries.GetTransactionHistoryQuery
{
    public class GetTransactionHistoryHandler : IRequestHandler<GetTransactionHistoryQuery, BaseResponse<IEnumerable<TransactionDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetTransactionHistoryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<TransactionDto>>> Handle(GetTransactionHistoryQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<TransactionDto>>();
            var transactions = await _repositoryManager.TransactionRepository.GetTransactionsHistoryForWallet(request.WalletId);
            var transactionsDto = _mapper.Map<List<TransactionDto>>(transactions);           
            response.Data = transactionsDto;
            response.IsSuccess = true;
            response.Message = "Transaction History Recieved successfully";
            return response;

        }
    }
}
