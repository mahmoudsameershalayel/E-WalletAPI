using AutoMapper;
using E_Wallet.API.Contracts;
using E_Wallet.API.Data.Enums;
using E_Wallet.API.Data.Exceptions.NotFoundExceptions;
using E_Wallet.API.UseCases.DTOs.PaymentDTOs;
using E_Wallet.API.UseCases.DTOs.RechargeDTOs;
using E_Wallet.API.UseCases.Payments.Queries.GetPaymentByIdQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Recharge.Queries.GetRechargeByRechargeCodeQuery
{
    public class GetRechargeByCodeHandler : IRequestHandler<GetRechargeByCodeQuery, BaseResponse<RechargeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        public GetRechargeByCodeHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<BaseResponse<RechargeDto>> Handle(GetRechargeByCodeQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<RechargeDto>();
            var recharge = await _repositoryManager.RechargeRepository.GetRechargeByCode(request.RechargeCode);
            if (recharge == null) throw new RechargeNotFoundException(request.RechargeCode);
            var dto = _mapper.Map<RechargeDto>(recharge);
            if (recharge.RechargeCodeStatus == RechargeCodeStatus.Pending)
            {
                response.Data = dto;
                response.IsSuccess = false;
                response.Message = "Your code status is PENDING you must wait until your recharge point admin ACTIVATE your code";
            }
            else {
                response.Data = dto;
                response.IsSuccess = true;
                response.Message = "Your code status is ACTIVATE you can use it";
            }
            return response;
        }
    }
}
