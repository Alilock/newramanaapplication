using System;
using Domain.Entities.Membership;
using Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.CQRS.AccountModule
{
	public class LoginCommand :IRequest<AppUser>
	{
		public string Email { get; set; } = null!;
		public string Password { get; set; } = null!;

        public class LoginCommandHandler : IRequestHandler<LoginCommand, AppUser>
        {
            private readonly SignInManager<AppUser> signinManager;

            public LoginCommandHandler(SignInManager<AppUser> signinManager)
            {
                this.signinManager = signinManager;
            }

            public async Task<AppUser?> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                AppUser user = new AppUser();

                user = await signinManager.UserManager.FindByEmailAsync(request.Email);
                if(user is null)
                {
                    return null;
                }

                var result = await signinManager.CheckPasswordSignInAsync(user, request.Password, true);

                if (result.IsLockedOut)
                {
                    return null;
                }


                if (result.IsNotAllowed)
                {

                    return null;
                }



                if (!user.EmailConfirmed)
                {

                    return null;
                }


                if (result.Succeeded)
                {
                    return user;
                }

                return null;
            }
        }
    }
}

