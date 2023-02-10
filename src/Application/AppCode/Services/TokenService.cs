using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities.Membership;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.AppCode.Services
{
    public class TokenService : ITokenService
    {
        private readonly TokenServiceOptions options;

        public TokenService(IOptions<TokenServiceOptions> options)
        {
            this.options = options.Value;
        }

        public string BuildToken(AppUser user)
        {
            var claims = new[] {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
                };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.options.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(this.options.Issuer, this.options.Audience, claims,
                expires: DateTime.UtcNow.AddHours(1), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public bool ValidateToken(string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(this.options.Key);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = this.options.Issuer,
                    ValidAudience = this.options.Audience,
                    IssuerSigningKey = mySecurityKey,
                    ClockSkew = TimeSpan.Zero,
                    ValidateLifetime = true,
                    LifetimeValidator = (notBefore, expires, securityToken, validationParameters) =>
                    {
                        return expires >= DateTime.UtcNow;
                    }
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }


    public class TokenServiceOptions
    {
        public string? Issuer { get; set; } = null!;
        public string? Audience { get; set; } = null!;
        public string Key { get; set; } = null!;
        public int DurationMinutes { get; set; }
    }
}

