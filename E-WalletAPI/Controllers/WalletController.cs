using E_Wallet.API.Data.Enums;
using E_Wallet.API.UseCases.Users.Queries.GetCustomerByUserIdQuery;
using E_Wallet.API.UseCases.Wallets.Commands.CreateWalletCommand;
using E_Wallet.API.UseCases.Wallets.Queries.GetAllWalletsQuery;
using E_Wallet.API.UseCases.Wallets.Queries.GetwalletByCustomerIdQuery;
using E_Wallet.API.UseCases.Wallets.Queries.GetWalletByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_WalletAPI.Controllers
{
   
    public class WalletController : BaseController
    {
        private readonly IMediator _mediator;
        public WalletController(IMediator mediator)
        {
                _mediator = mediator;
        }
        /// <summary>
        ///Create New Wallet - CUSTOMER ROLE 
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> CreateMyWallet(CurrencyType currency)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var customer = await _mediator.Send(new GetCustomerByUserIdQuery() { ApplicationUserId = currentUserId });
            return Ok(await _mediator.Send(new CreateWalletCommand() { CustomerId = customer.Id , Currency = currency }));
        }
        /// <summary>
        ///Get My Wallets - CUSTOMER ROLE 
        /// </summary>
        [HttpGet]                                               
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetMyWallets()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var customer = await _mediator.Send(new GetCustomerByUserIdQuery() { ApplicationUserId = currentUserId });
            return Ok(await _mediator.Send(new GetWalletByCustomerIdQuery() { CustomerId = customer.Id }));
        }

        /// <summary>
        ///Create New Wallet - ADMIN ROLE 
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateWalletAsAdmin(CreateWalletCommand command)
        {
            if (command is null) return BadRequest();
            var response = await _mediator.Send(command);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response);

        }
        /// <summary>
        ///Get All Wallets - ADMIN ROLE 
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetAllWalletsAsync() {
            return Ok(await _mediator.Send(new GetAllWalletsQuery()));
        }
        /// <summary>
        ///Get Wallet By Id - ADMIN ROLE 
        /// </summary>
        [HttpGet("{walletId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetWalletById(int walletId)
        {
            return Ok(await _mediator.Send(new GetWalletByIdQuery() { WalletId = walletId}));
        }
       
    }
}
