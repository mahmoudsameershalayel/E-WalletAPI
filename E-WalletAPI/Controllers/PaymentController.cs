using E_Wallet.API.Infrastructure.DTOs.PaymentDTOs;
using E_Wallet.API.Service.Contracts;
using E_Wallet.API.UseCases.Payments.Commands.CreatePaymentCommand;
using E_Wallet.API.UseCases.Payments.Queries.GetAllPaymentsQuery;
using E_Wallet.API.UseCases.Payments.Queries.GetPaymentByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_WalletAPI.Controllers
{

    public class PaymentController : BaseController
    {
        private readonly IServiceManager _service;
        private readonly IMediator _mediator;
        public PaymentController(IServiceManager service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> GetAllPaymentServices()
        {
            return Ok(await _mediator.Send(new GetAllPaymentsQuery()));
        }
       [HttpGet("{paymentId}", Name = "PaymentById")]
        [Authorize]

        public async Task<IActionResult> GetPaymentById(int paymentId)
        {
            return Ok(await _mediator.Send(new GetPaymentByIdQuery() { PaymentId = paymentId}));
        } 
        /// <summary>
        ///Create New Payment Service 
        /// </summary>
        /// <param name="dto">The Payment Service data.</param>
        /// <response code="204">The category created successfully.</response>
        [HttpPost]
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> CreatePaymentService([FromForm] CreatePaymentCommand command)
        {
            if (command is null) return BadRequest();
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
           
        }
        /*[HttpPut("{paymentId}")]
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> UpdatePaymentService(int paymentId, [FromForm] PaymentForUpdateDto dto)
        {
            await _service.PaymentService.UpdatePaymentAsync(paymentId, dto);
            return Ok(dto);
        }
        [HttpDelete("{paymentId}")]
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> DeletePaymentService(int paymentId)
        {
            await _service.PaymentService.DeletePaymentAsync(paymentId);
            return NoContent();
        }   */

    }
}
