using Optera.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Models
{
    public class ComponentForm : BaseModel
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public long ComponentId { get; set; }
        public Component Component { get; set; }

        public virtual ICollection<ComponentFormControl> ComponentFormControls { get; set; }
        public string? Model { get; set; }
    }
}
