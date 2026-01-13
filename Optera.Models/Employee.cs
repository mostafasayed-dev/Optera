using Optera.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Optera.Models
{
    public class Employee : BaseModel
    {
        public required string Name { get; set; }
        public required char Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Mobile { get; set; }

        public required long NationalityId { get; set; }
        public virtual CategoryItem Nationality { get; set; }

        public string? HomeAddress { get; set; }
        public DateTime JoiningDate { get; set; }

        public required long PositionId { get; set; }
        public virtual CategoryItem Position { get; set; }

        public long? CountryId { get; set; }
        public virtual Country Country { get; set; }

        public long? CityId { get; set; }
        public virtual City City { get; set; }

        public long? RegionId { get; set; }
        public virtual Region Region { get; set; }

        public string? Image { get; set; }
        public string? Signature { get; set; }

        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        public ICollection<Quotation> Quotations { get; set; }
    }
}
