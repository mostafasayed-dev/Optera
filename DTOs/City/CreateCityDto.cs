using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.City
{
    public class CreateCityDto
    {
        public string Name { get; set; }
        public string Name_OtherLanguage { get; set; }

        public long CountryId { get; set; }
    }
}
