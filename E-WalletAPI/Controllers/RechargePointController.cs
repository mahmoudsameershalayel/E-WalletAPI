using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.Data.Enums;
using E_Wallet.API.UseCases.Recharge.Commands.CreateRechargeCommand;
using E_Wallet.API.UseCases.Recharge.Queries.GetRechargeByRechargeCodeQuery;
using E_Wallet.API.UseCases.RechargePoints.Commands.ActivateRechargeCodeCommand;
using E_Wallet.API.UseCases.RechargePoints.Commands.CrateRechargePointCommand;
using E_Wallet.API.UseCases.RechargePoints.Queries.GetAllRechargePointsQuery;
using E_Wallet.API.UseCases.Users.Queries.GetCustomerByUserIdQuery;
using E_Wallet.API.UseCases.Wallets.Commands.CreateWalletCommand;
using E_Wallet.API.UseCases.Wallets.Queries.CheckCustomerWalletQuery;
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
        /// <summary>
        ///ACTIVATE recharge code- RECHARGE POINT ROLE
        /// </summary>
        [HttpPut("{rechargeCode}")]
        [Authorize(Roles = "RechargePoint")]
        public async Task<IActionResult> ActivateRechargeCode(string rechargeCode)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var recharge = await _mediator.Send(new GetRechargeByCodeQuery() { RechargeCode = rechargeCode });
            var result1 = await _mediator.Send(new CheckUserWalletQuery() { ApplicationUserId = currentUserId, WalletId = recharge.Data.RechargeWalletId });
            if (!result1) return BadRequest("You Can not activate recharge code , because the code net belong to your repositoy point!!");
            var response = await _mediator.Send(new ActivateRechargeCodeCommand() {RechargeCode = rechargeCode });
            return Ok(response);
        }
    }
}
