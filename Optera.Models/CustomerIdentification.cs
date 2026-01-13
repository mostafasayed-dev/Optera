using Optera.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Models
{
    public class CustomerIdentification : BaseModel
    {
        public required long IdentificationTypeId { get; set; }
        public virtual required CategoryItem IdentificationType { get; set; }

        public required string IdentificationNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public long? CountryId { get; set; }
        public virtual Country? Country { get; set; }

        public long? CityId { get; set; }
        public City? City { get; set; }

        public string? Document { get; set; }

        public required long CustomerId { get; set; }
        public virtual required Customer Customer { get; set; }
    }
}
