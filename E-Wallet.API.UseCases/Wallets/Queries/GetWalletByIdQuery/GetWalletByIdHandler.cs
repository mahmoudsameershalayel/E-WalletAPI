using AutoMapper;
using E_Wallet.API.Contracts;
using E_Wallet.API.Data.Exceptions.NotFoundExceptions;
using E_Wallet.API.UseCases.DTOs.WalletDTOs;
using E_Wallet.API.UseCases.Payments.Queries.GetPaymentByIdQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Wallets.Queries.GetWalletByIdQuery
{
    public class GetWalletByIdHandler : IRequestHandler<GetWalletByIdQuery , BaseResponse<WalletDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetWalletByIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<BaseResponse<WalletDto>> Handle(GetWalletByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<WalletDto>();
            var wallet = await _repositoryManager.WalletRepository.GetWalletByIdAsync(request.WalletId);
            if (wallet is null) throw new WalletNotFoundException(request.WalletId);
            response.Data = _mapper.Map<WalletDto>(wallet);
            response.IsSuccess = true;
            response.Message = "The Wallet recieved Successfully";
            return response;
        }
    }
}
