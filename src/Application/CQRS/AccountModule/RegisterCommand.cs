using Application.AppCode.Services;
using Domain.Entities.Membership;
using Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AccountModule
{
    public class RegisterCommand:IRequest<ResponseUser>
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; }= null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ResponseUser>
        {
            private readonly UserManager<AppUser> userManager;
            private readonly IEmailService emailService;
            public RegisterCommandHandler(UserManager<AppUser> userManager, IEmailService emailService)
            {
                this.userManager = userManager;
                this.emailService = emailService;
            }
            public async Task<ResponseUser> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                ResponseUser response = new();
                var user = await userManager.FindByEmailAsync(request.Email);
                if (user != null)
                {
                    response.StatusCode = StatusCodes.Status403Forbidden;
                    response.Message = "Bu email ilə artıq qeydiyyatdan keçilib";
                    return response;
                }
                user = new AppUser
                {
                    Email = request.Email,
                    Name = request.Name,
                    SurName = request.Surname,
                    UserName = request.Surname,
                    PhoneNumber = request.PhoneNumber
                };

                  var countOfUserName = await userManager.Users.CountAsync(u => u.UserName.StartsWith(user.UserName), cancellationToken);

                if (countOfUserName>0)
                {
                    user.UserName = $"{request.Surname}.{countOfUserName + 1}";
                }
                Random rnd = new Random();
                var confirmCode = rnd.Next(1000, 9999);
                user.ConfirmCode = confirmCode;
                var result = await userManager.CreateAsync(user, request.Password);

                if (!result.Succeeded)
                {
                    foreach (IdentityError item in result.Errors)
                    {
                        response.StatusCode = StatusCodes.Status403Forbidden;
                        response.Message = item.Description;
                        return response;
                    }   

                }
                await emailService.SendEmailAsync(request.Email, "Resgistration", $"Confirm code {confirmCode}");
                response.StatusCode = StatusCodes.Status201Created;
                response.Message = "Emailinizə təsdiq mesajı göndərildi.";
                response.UserId = user.Id;

                return response;
            }
        }

    }
}
