using Optera.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Models
{
    public class ReferenceNumber : BaseModel
    {
        public required string Prefix { get; set; }
        public string? Segment1 { get; set; }
        public string? Segment2 { get; set; }
        public string? Segment3 { get; set; }
        public string? Segment4 { get; set; }
        public string? Segment1_Format { get; set; }
        public string? Segment2_Format { get; set; }
        public string? Segment3_Format { get; set; }
        public string? Segment4_Format { get; set; }
        public required long LastSequence { get; set; }
    }
}
