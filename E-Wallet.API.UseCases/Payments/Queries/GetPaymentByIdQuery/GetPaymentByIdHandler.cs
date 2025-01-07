using AutoMapper;
using E_Wallet.API.Contracts;
using E_Wallet.API.Data.Exceptions.NotFoundExceptions;
using E_Wallet.API.UseCases.DTOs.PaymentDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Payments.Queries.GetPaymentByIdQuery
{
    public class GetPaymentByIdHandler : IRequestHandler<GetPaymentByIdQuery, BaseResponse<PaymentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        public GetPaymentByIdHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<BaseResponse<PaymentDto>> Handle(GetPaymentByIdQuery query, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<PaymentDto>();
            var payment = await _repositoryManager.PaymentRepository.GetPaymentByIdAsync(query.PaymentId);
            if (payment == null) throw new PaymentNotFoundException(query.PaymentId);
            response.Data = _mapper.Map<PaymentDto>(payment);
            response.IsSuccess = true;
            return response;
        }
    }
}
