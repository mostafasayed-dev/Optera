namespace Optera.Identity.JWT
{
    public class JwtToken
    {
        public long? UserId { get; set; }
        public string? JWT { get; set; }
        public double? Expires_in { get; set; }
    }
}
