using Optera.Shared.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace Optera.Configuration.Models
{
    public class ComponentForm : BaseModel
    {
        [MaxLength(50)]
        public required string Name { get; set; }
        [MaxLength(50)]
        public string? Label { get; set; }

        public Guid ComponentId { get; set; }
        public Component Component { get; set; }

        public virtual ICollection<ComponentFormControl> ComponentFormControls { get; set; }
        [MaxLength(50)]
        public string? Model { get; set; }
    }
}
