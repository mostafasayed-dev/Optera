using Optera.Shared.Domain;
using System.ComponentModel.DataAnnotations;

namespace Optera.Query.Models
{
    public class User : BaseModel
    {
        public string? UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        public string? Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
    }
}
