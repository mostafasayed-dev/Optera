using Optera.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Models
{
    public class City : BaseModel
    {
        public required string Name { get; set; }
        public string? Name_OtherLanguage { get; set; }

        public required long CountryId { get; set; }
        public virtual Country Country { get; set; }

        public ICollection<Region> Regions { get; set; }
    }
}
