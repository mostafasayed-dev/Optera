using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.Core
{
    public class GetComponentFormControlDto
    {
        public string Name { get; set; }
        public string Field { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public bool Required { get; set; }
        public bool Enabled { get; set; }
        public bool Visible { get; set; }
        public string? Mask { get; set; }
        public int? Min { get; set; }
        public int? Max { get; set; }
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
        public string? DefaultValue { get; set; }
    }
}