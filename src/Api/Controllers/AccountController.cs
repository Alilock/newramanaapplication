using Application.CQRS.AccountModule;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;
        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        //[Route("/register")]

        public async Task<IActionResult> Register(RegisterCommand command)
        {

            var respone = await mediator.Send(command);
            return StatusCode(respone.StatusCode, respone);
        }
        [Route("/email-confirm")]

        [HttpGet]

        public  async Task<IActionResult> EmailConfirm(RegisterConfirmationCommand command)
        {
            var response = await mediator.Send(command);
            return StatusCode(response.StatusCode, response);
        }
    }
}
