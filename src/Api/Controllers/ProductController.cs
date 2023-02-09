using System;
using Application.CQRS.CategoryModule;
using Application.CQRS.ProductModule;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController :ControllerBase
	{
        private readonly IMediator mediator;

        public ProductController(IMediator mediatr)
        {
            this.mediator = mediatr;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateCommand command)
        {
            var response = await mediator.Send(command);
            return StatusCode(response.StatusCode, response);
            //return StatusCode(202, command);

        }
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] ProductAllQuery query)
        {
            var response = await mediator.Send(query);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] ProductSingleQuery query)
        {
            var response = await mediator.Send(query);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] ProductDeleteCommand command)
        {
            var response = await mediator.Send(command);
            return StatusCode(response.StatusCode, response);
        }


    }
}

