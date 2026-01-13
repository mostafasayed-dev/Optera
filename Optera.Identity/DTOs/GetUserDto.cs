namespace Optera.Identity.DTOs
{
    public class GetUserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public int Locked { get; set; }
    }
}
