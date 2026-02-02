using Optera.Shared.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace Optera.HRM.Models
{
    public class Employee : BaseModel
    {
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [MaxLength(100)]
        public string? MiddleName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }
        public char Gender { get; set; } = 'M';
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
    }
}
