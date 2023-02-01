using System;
using Application.CQRS.ColorAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController :ControllerBase
	{

        private readonly IMediator mediator;

        public ColorController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] ColorAllQuery query)
        {
            var response = await mediator.Send(query);
            return StatusCode(response.StatusCode, response);
        }
    }
}

