using Optera.DTOs.CustomerContactPerson;
using Optera.DTOs.CustomerIdentification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.Customer
{
    public class CreateCustomerDto
    {
        public required string Name { get; set; }
        public string? Name_OtherLanguage { get; set; }
        public string? BrandName { get; set; }
        public string? BrandName_OtherLanguage { get; set; }
        public long? ClassId { get; set; }
        public long? SectorId { get; set; }
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
        public long? CityId { get; set; }
        public long? RegionId { get; set; }
        public ICollection<CreateCustomerIdentificationDto>? CustomerIdentifications { get; set; }
        public ICollection<CreateCustomerContactPersonDto>? CustomerContactPersons { get; set; }
    }
}
