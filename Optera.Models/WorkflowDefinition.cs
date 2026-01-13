using Optera.Models.Base;
using Optera.Utils.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Models
{
    public class WorkflowDefinition : BaseModel
    {
        public required string Name { get; set; }
        public virtual ICollection<WorkflowStep> WorkflowSteps { get; set; }
        public virtual ICollection<WorkflowInstance> WorkflowInstances { get; set; }
        public virtual ICollection<WorkflowTransition> WorkflowTransitions { get; set; }
    }
}
