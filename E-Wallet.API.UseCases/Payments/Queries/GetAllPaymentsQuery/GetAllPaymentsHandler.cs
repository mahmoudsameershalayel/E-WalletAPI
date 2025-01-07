using AutoMapper;
using E_Wallet.API.Contracts;
using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.UseCases.DTOs.PaymentDTOs;
using E_Wallet.API.UseCases.Payments.Commands.CreatePaymentCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Payments.Queries.GetAllPaymentsQuery
{
    public class GetAllPaymentsHandler : IRequestHandler<GetAllPaymentsQuery, BaseResponse<IEnumerable<PaymentDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        public GetAllPaymentsHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<BaseResponse<IEnumerable<PaymentDto>>> Handle(GetAllPaymentsQuery query, CancellationToken collectionToken)
        {
            var response = new BaseResponse<IEnumerable<PaymentDto>>();
            try
            {
                var payments = await _repositoryManager.PaymentRepository.GetAllPaymentsAsync();
                response.Data = _mapper.Map<List<PaymentDto>>(payments);
                response.IsSuccess = true;
                response.Message = "The Payments Retrived Successfully";
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
    }
}
