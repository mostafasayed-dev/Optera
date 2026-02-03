using Optera.Shared.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace Optera.Configuration.Models
{
    public class Component : BaseModel
    {
        [MaxLength(50)]
        public required string Name { get; set; }
        [MaxLength(50)]
        public string? Title { get; set; }
        public virtual ICollection<ComponentForm> ComponentForms { get; set; }
    }
}
