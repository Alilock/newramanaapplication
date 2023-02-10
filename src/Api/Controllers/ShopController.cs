 using System;
using Application.CQRS.OrderModule;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController :ControllerBase
	{
        private readonly IMediator _mediator;

        public ShopController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Checkout([FromBody]CreateOrder command)
        {
            var response =  await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("orders")]

        public async Task<IActionResult> Get ([FromRoute]GetOrdersQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("orders/{Id}")]
        public async Task<IActionResult> GetUserOrder([FromRoute] GetOrderByUser query)
        {
            var response = await _mediator.Send(query);
                   if (response is null) return NotFound();
            return Ok(response);
        }

        [HttpGet("orderdetail/{Id}")]
        public async Task<IActionResult> GetOrderDetail([FromRoute] OrderSingleQuery query)
        {
            var response = await _mediator.Send(query);
            if (response is null) return NotFound();

            return Ok(response);
        }
    }
}

