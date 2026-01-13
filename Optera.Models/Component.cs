using Optera.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Models
{
    public class Component: BaseModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public virtual ICollection<ComponentForm> ComponentForms { get; set; }
    }
}
