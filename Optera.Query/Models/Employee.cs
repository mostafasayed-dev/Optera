using Optera.Shared.Core.Domain;

namespace Optera.Query.Models
{
    public class Employee : BaseModel
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public char Gender { get; set; } = 'M';
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
    }
}
