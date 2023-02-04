using Domain.Entities.Membership;
using Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.AccountModule
{
    public class RegisterConfirmationCommand : IRequest<ResponseUser>
    {
        public int ConfirmCode { get; set; } 
        public int UserId { get; set; } 
        public class RegisterConfirmationCommandHandler :IRequestHandler<RegisterConfirmationCommand,ResponseUser>
        {
            private readonly UserManager<AppUser> userManager;

            public RegisterConfirmationCommandHandler(UserManager<AppUser> userManager)
            {
                this.userManager = userManager;
            }

            public async Task<ResponseUser>Handle(RegisterConfirmationCommand request,CancellationToken cancellationToken)
            {
              var user =await userManager.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);
                if(user is null)
                {
                    return new ResponseUser() { StatusCode = 404, Message = "User not found" };
                }

                if (user.ConfirmCode == request.ConfirmCode)
                {
                    user.EmailConfirmed = true;
                    return new ResponseUser() { Message = "Emailiniz tesdiqlendi", StatusCode = 200 };

                }
                else {
                    return new ResponseUser() { Message = "Tesdiq kodu duzgun deil", StatusCode = 403 };
                }


            }
        }
    }
}
