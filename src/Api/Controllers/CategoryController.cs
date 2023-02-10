using System;
using Application.CQRS.CategoryModule;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateCommand command)
        {
            var response = await mediator.Send(command);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute]CategoryAllQuery query)
        {
            var response = await mediator.Send(query);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById ([FromRoute]CategorySingleQuery query)
        {
            var response = await mediator.Send(query);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet]
        [Route("categorytree")]
        public async Task<IActionResult> GetTreeCategory([FromRoute]CategoryTreeQuery query)
        {
            var response = await mediator.Send(query);

            return StatusCode(response.StatusCode, response);
        }

    }
}

