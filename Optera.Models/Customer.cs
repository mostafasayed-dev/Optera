using Optera.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Optera.Models
{
    public class Customer : BaseModel
    {
        public string? Code { get; set; }
        public required string Name { get; set; }
        public string? Name_OtherLanguage { get; set; }
        public string? BrandName { get; set; }
        public string? BrandName_OtherLanguage { get; set; }

        public long? ClassId { get; set; }
        public virtual CategoryItem? Class { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Mobile { get; set; }
        public string? LandLine { get; set; }
        public string? Fax { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? BuildingNo { get; set; }
        public string? SecondaryNo { get; set; }
        public string? PostalCode { get; set; }
        public string? Street { get; set; }
        public string? Street_OtherLanguage { get; set; }
        public string? District { get; set; }
        public string? District_OtherLanguage { get; set; }

        public long? CountryId { get; set; }
        public virtual Country? Country { get; set; }

        public long? CityId { get; set; }
        public virtual City? City { get; set; }

        public long? RegionId { get; set; }
        public virtual Region? Region { get; set; }

        public long? SectorId { get; set; }
        public virtual CategoryItem? Sector { get; set; }

        public virtual ICollection<CustomerIdentification>? CustomerIdentifications { get; set; }
        public virtual ICollection<CustomerContactPerson>? CustomerContactPersons { get; set; }
    }
}
