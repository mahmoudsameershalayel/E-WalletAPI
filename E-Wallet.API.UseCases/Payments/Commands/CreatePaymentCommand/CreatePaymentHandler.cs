using AutoMapper;
using E_Wallet.API.Contracts;
using E_Wallet.API.Data.DBEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Payments.Commands.CreatePaymentCommand
{
    public class CreatePaymentHandler : IRequestHandler<CreatePaymentCommand, BaseResponse<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CreatePaymentHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<BaseResponse<bool>> Handle(CreatePaymentCommand command, CancellationToken collectionToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var payment = _mapper.Map<Payment>(command);
                _repositoryManager.PaymentRepository.CreatePayment(payment);
                await _repositoryManager.SaveAsync();
                response.Data = true;
                response.IsSuccess = true;
                response.Message = "The Payment Created Successfully";
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
    }
}
