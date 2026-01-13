using Optera.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Models
{
    public class ComponentFormControl : BaseModel
    {
        public long ComponentFormId { get; set; }
        public ComponentForm ComponentForm { get; set; }
        public string Name { get; set; }
        public string? Field { get; set; }
        public string Label { get; set; }
        public string? Type { get; set; }
        public bool Required { get; set; } = false;
        public bool Enabled { get; set; } = true;
        public bool Visible { get; set; } = true;
        public string? Mask { get; set; }
        public int? Min { get; set; }
        public int? Max { get; set; }
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
        public string? DefaultValue { get; set; }

    }
}
