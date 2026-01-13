using Optera.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Models
{
    public class Region : BaseModel
    {
        public required string Name { get; set; }
        public string? Name_OtherLanguage { get; set; }

        public required long CityId { get; set; }
        public virtual City City { get; set; }
    }
}
