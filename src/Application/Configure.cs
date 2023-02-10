using Application.AppCode.Services;
using Application.DbContext;
using Domain.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace Application
{
    public static class Configure
    {
        public static void AddApplication(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddDbContext<AppDbContext>(cfg =>
            {
                cfg.UseNpgsql(configuration.GetConnectionString("defaultConnection"));

            });
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

          
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JWT:issuer"],
                    ValidAudience = configuration["JWT:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"])),
                    ClockSkew = TimeSpan.Zero,
                    
                    LifetimeValidator = (notBefore, expires, securityToken, validationParameters) =>
                    {
                        return expires >= DateTime.UtcNow.AddHours(5);
                    }

                };
            });
            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);

                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            });

            services.Configure<EmailServiceOptions>(config =>
            {
                configuration.GetSection("emailAccount").Bind(config);
            });
            services.Configure<TokenServiceOptions>(cfg =>
            {
                configuration.GetSection("jwt").Bind(cfg);
            });
            services.AddSingleton<ITokenService, TokenService>();
            services.AddSingleton<IEmailService, EmailService>();

        }
    }
}
