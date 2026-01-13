using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.CustomerIdentification
{
    public class GetCustomerIdentificationDto
    {
        public long IdentificationTypeId { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public long? CountryId { get; set; }
        public long? CityId { get; set; }
        public string? Document { get; set; }
    }
}
