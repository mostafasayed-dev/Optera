using Optera.DTOs.User;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Optera.Infrastructure.Services
{
    public interface ITokenService
    {
        public Token GenerateToken(IEnumerable<Claim> claims);
    }
}
