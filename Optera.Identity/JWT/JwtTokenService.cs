using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Optera.Identity.JWT
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtTokenService(IOptions<JwtSettings> options)
        {
            _jwtSettings = options.Value;
        }

        public JwtToken GenerateJwtToken(IEnumerable<Claim> claims)
        {
            var claimsList = claims.ToList();
            claimsList.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claimsList.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64));

            var signingKey = new SigningCredentials(
                new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256Signature
            );

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.ValidIssuer,
                audience: _jwtSettings.ValidAudience,
                claims: claimsList,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(_jwtSettings.ExpiresIn),
                signingCredentials: signingKey
            );

            return new JwtToken
            {
                JWT = new JwtSecurityTokenHandler().WriteToken(token),
                Expires_in = _jwtSettings.ExpiresIn
            };
        }
    }
}
