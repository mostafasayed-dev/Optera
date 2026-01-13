using Optera.DTOs.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Optera.Infrastructure.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Optera.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        private readonly string issuer;
        private readonly string audience;
        private readonly byte[] secret;
        private readonly int expiresIn;

        public TokenService(IConfiguration configuration)
        {
            issuer = configuration.GetSection("JWT:ValidIssuer").Value;
            audience = configuration.GetSection("JWT:ValidAudience").Value;
            secret = System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("JWT:Secret").Value);
            expiresIn = int.Parse(configuration.GetSection("JWT:ExpiresIn").Value);
        }

        public Token GenerateToken(IEnumerable<Claim> claims)
        {
            try
            {
                var signingKey = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(issuer, audience, claims, DateTime.Now, DateTime.Now.AddHours(expiresIn), signingKey);
                var handler = new JwtSecurityTokenHandler();

                var jwt = handler.WriteToken(token);

                return new Token { JWT = jwt, Expires_in = expiresIn };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
