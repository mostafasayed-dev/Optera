using System.ComponentModel.DataAnnotations;

namespace Optera.Identity.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public List<string> Roles { get; set; } = new();
    }
}
