using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.AppCode.Services;
using Application.CQRS.AccountModule;
using Domain.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ITokenService tokenService;
        public AccountController(IMediator mediator,ITokenService tokenService)
        {
            this.mediator = mediator;
            this.tokenService = tokenService;
        }

        [HttpPost]
        [Route("register")]

        public async Task<IActionResult> Register([FromBody]RegisterCommand command)
        {
            var respone = await mediator.Send(command);
            return StatusCode(respone.StatusCode, respone);
        }

        [HttpPost]
        [Route("emailconfirm")]
        public  async Task<IActionResult> EmailConfirm([FromBody]RegisterConfirmationCommand command)
        {
            var response = await mediator.Send(command);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var user = await mediator.Send(command);
            if(user is null)
            {
                return Unauthorized();
            }
            var token = tokenService.BuildToken(user);


            return Ok(new
            {
                error = false,
                accessToken = token
            }) ;
        }
        
    }
}
