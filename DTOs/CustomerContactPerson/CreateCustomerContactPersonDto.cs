using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Optera.DTOs.CustomerContactPerson
{
    public class CreateCustomerContactPersonDto
    {
        [Required]
        public string Name { get; set; }
        public string? Mobile { get; set; }
        public string? Phone { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public long PositionId { get; set; }
        public bool IsPrimary { get; set; } = false;
    }
}
