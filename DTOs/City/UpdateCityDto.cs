using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.City
{
    public class UpdateCityDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Name_OtherLanguage { get; set; }
        public long CountryId { get; set; }
        public string Status { get; set; }
    }
}
