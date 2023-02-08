﻿using System;
using Application.CQRS.OrderModule;
using MediatR;
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
        public async Task<ActionResult> Checkout([FromForm]CreateOrder command)
        {
            var response =  await _mediator.Send(command);
            return Ok(response);
        }
    }
}
