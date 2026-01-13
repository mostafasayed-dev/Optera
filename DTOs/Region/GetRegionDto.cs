using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.Region
{
    public class GetRegionDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Name_OtherLanguage { get; set; }

        public string CityName { get; set; }
        public long CityId { get; set; }
        public string CountryName { get; set; }

        public string Status { get; set; }
    }
}
