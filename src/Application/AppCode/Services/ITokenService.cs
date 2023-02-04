using System;
using Domain.Entities.Membership;

namespace Application.AppCode.Services
{
	
        public interface ITokenService
        {
            string BuildToken(AppUser user);
            bool ValidateToken(string token);
        }
}

