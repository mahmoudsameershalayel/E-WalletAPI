using E_Wallet.API.Data.Enums;
using E_Wallet.API.UseCases.RechargePoints.Commands.CrateRechargePointCommand;
using E_Wallet.API.UseCases.RechargePoints.Queries.GetAllRechargePointsQuery;
using E_Wallet.API.UseCases.Users.Queries.GetCustomerByUserIdQuery;
using E_Wallet.API.UseCases.Wallets.Commands.CreateWalletCommand;
using E_Wallet.API.UseCases.Wallets.Queries.GetwalletByCustomerIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_WalletAPI.Controllers
{

    public class RechargePointController : BaseController
    {
        private readonly IMediator _mediator;
        public RechargePointController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        ///Create New Recharge Point - ADMIN ROLE 
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateRechargePoint(CreateRechargePointCommand command)
        {
            if (command is null) return BadRequest();
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        /// <summary>
        ///Get All Recharge Points - ADMIN & CUSTOMER ROLE
        /// </summary>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllRechargePoints()
        {
            var response = await _mediator.Send(new GetAllRechargePointsQuery());
            return Ok(response);
        }

      
    }
}
