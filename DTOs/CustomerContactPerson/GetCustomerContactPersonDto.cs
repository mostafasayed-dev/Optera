using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Optera.DTOs.CustomerContactPerson
{
    public class GetCustomerContactPersonDto
    {
        public string Name { get; set; }
        public string? Mobile { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public long PositionId { get; set; }
        public bool IsPrimary { get; set; }
    }
}
