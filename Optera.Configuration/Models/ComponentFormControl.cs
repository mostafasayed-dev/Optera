using Optera.Shared.Domain;
using System.ComponentModel.DataAnnotations;

namespace Optera.Configuration.Models
{
    public class ComponentFormControl : BaseModel
    {
        public Guid ComponentFormId { get; set; }
        public ComponentForm ComponentForm { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }
        [MaxLength(50)]
        public string? Field { get; set; }
        [MaxLength(50)]
        public string? Label { get; set; }
        [MaxLength(25)]
        public string? Type { get; set; }
        public bool Required { get; set; } = false;
        public bool Enabled { get; set; } = true;
        public bool Visible { get; set; } = true;
        [MaxLength(50)]
        public string? Mask { get; set; }
        public int? Min { get; set; }
        public int? Max { get; set; }
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
        [MaxLength(50)]
        public string? DefaultValue { get; set; }
    }
}
