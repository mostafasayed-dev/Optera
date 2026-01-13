using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.Country
{
    public class GetCountryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Name_OtherLanguage { get; set; }
        public string ISOCode { get; set; }
        public string Status { get; set; }
    }
}
