using Optera.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Models
{
    public class CustomerContactPerson : BaseModel
    {
        public required string Name { get; set; }
        public string? Mobile { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public required long PositionId { get; set; }
        public virtual CategoryItem Position { get; set; }

        public bool IsPrimary { get; set; } = false;

        public long CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
