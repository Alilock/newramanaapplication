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

        //[HttpGet]
        //public async Task<IActionResult> GetAll ()

    }
}

