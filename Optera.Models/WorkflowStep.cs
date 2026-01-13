using Optera.Models.Base;
using Optera.Utils.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Models
{
    public class WorkflowStep : BaseModel
    {
        public long WorkflowDefinitionId { get; set; }
        public virtual WorkflowDefinition WorkflowDefinition { get; set; }
        public required string Name { get; set; }
        public int Order { get; set; }
        public bool IsFinal { get; set; }
        public ICollection<WorkflowTransition> FromStepTransitions { get; set; }
        public ICollection<WorkflowTransition> ToStepTransitions { get; set; }
        public virtual ICollection<WorkflowInstance> WorkflowInstances { get; set; }
    }
}
