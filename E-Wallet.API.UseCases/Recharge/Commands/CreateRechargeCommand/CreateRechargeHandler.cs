using AutoMapper;
using E_Wallet.API.Contracts;
using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.Data.Enums;
using E_Wallet.API.UseCases.RechargePoints.Commands.CrateRechargePointCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Recharge.Commands.CreateRechargeCommand
{
    public class CreateRechargeHandler : IRequestHandler<CreateRechargeCommand, BaseResponse<string>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly Random _random = new Random();

        public CreateRechargeHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<BaseResponse<string>> Handle(CreateRechargeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<string>();
            try
            {
                var builder = new StringBuilder(20);
                char offset = 'a';
                const int lettersOffset = 26;

                for (var i = 0; i < 20; i++)
                {
                    var @char = (char)_random.Next(offset, offset + lettersOffset);
                    builder.Append(@char);
                }

                var rechargeCode = builder.ToString().ToLower();
                var recharge = new Data.DBEntities.Recharge()
                {

                    RechargeCode = rechargeCode,
                    RechargeCodeStatus = RechargeCodeStatus.Pending,
                    RechargePointId = request.RechargePointId,
                    WalletId = request.WalletId,

                };
                _repositoryManager.RechargeRepository.CreateRecharge(recharge);
                await _repositoryManager.SaveAsync();
                response.Data = rechargeCode;
                response.IsSuccess = true;
                response.Message = "The Recharge Created Successfully And The Code Status Is Pending You Must Wait Until The Recharge Point Admin Activate Your Code!!";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
