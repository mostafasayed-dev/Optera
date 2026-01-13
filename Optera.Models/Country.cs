using Optera.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Models
{
    public class Country : BaseModel
    {
        public required string Name { get; set; }
        public string? Name_OtherLanguage { get; set; }
        public string? ISOCode { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
