namespace Optera.Identity.JWT
{
    public class JwtToken
    {
        public string? UserId { get; set; }
        public string? JWT { get; set; }
        public double? Expires_in { get; set; }
    }
}
