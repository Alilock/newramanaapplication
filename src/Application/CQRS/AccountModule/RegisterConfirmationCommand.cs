using Domain.Entities.Membership;
using Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.AccountModule
{
    public class RegisterConfirmationCommand : IRequest<ResponseUser>
    {
        public string Token { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public class RegisterConfirmationCommandHandler :IRequestHandler<RegisterConfirmationCommand,ResponseUser>
        {
            private readonly UserManager<AppUser> userManager;

            public RegisterConfirmationCommandHandler(UserManager<AppUser> userManager)
            {
                this.userManager = userManager;
            }

            public async Task<ResponseUser>Handle(RegisterConfirmationCommand request,CancellationToken cancellationToken)
            {
                ResponseUser response = new();
                response.StatusCode = 200;
                response.Message = request.Email;
                    return response;
            }

          
        }
    }
}
