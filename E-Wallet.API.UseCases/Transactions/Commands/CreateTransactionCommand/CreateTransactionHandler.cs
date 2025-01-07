using AutoMapper;
using E_Wallet.API.Contracts;
using E_Wallet.API.Data.DBEntities;
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
                response.Data = true;
                response.IsSuccess = true;
                response.Message = "The transaction Created Successfully";
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
    }
}
