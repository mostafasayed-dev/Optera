using System.Security.Claims;

namespace Optera.Identity.JWT
{
    public interface IJwtTokenService
    {
        public JwtToken GenerateJwtToken(IEnumerable<Claim> claims);
    }
}
