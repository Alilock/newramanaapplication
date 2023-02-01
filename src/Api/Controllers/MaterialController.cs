using System;
using Application.CQRS.GenderModule;
using Application.CQRS.MaterialModule;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController :ControllerBase
	{
        private readonly IMediator mediator;

        public MaterialController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] MaterialAllQuery query)
        {
            var response = await mediator.Send(query);
            return StatusCode(response.StatusCode, response);
        }
    }
}

