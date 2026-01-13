using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.Region
{
    public class CreateRegionDto
    {
        public string Name { get; set; }
        public string? Name_OtherLanguage { get; set; }

        public long CityId { get; set; }
    }
}
