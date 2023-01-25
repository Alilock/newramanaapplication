using Application.CQRS.GenderModule;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IMediator mediator;

        public GenderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute]GenderAllQuery query)
        {
            var response = await mediator.Send(query);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute]GenderSingleQuery query)
        {
            var response = await mediator.Send(query);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GenderCreateCommand command)
        {
            var response = await mediator.Send(command);
            return StatusCode(response.StatusCode,response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute]GenderDeleteCommand command)
        {
            var response = await mediator.Send(command);
            return StatusCode(response.StatusCode, response);
        }
    }
}
