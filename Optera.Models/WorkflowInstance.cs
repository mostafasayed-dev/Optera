using Optera.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Models
{
    public class WorkflowInstance : BaseModel
    {
        public long WorkflowDefinitionId { get; set; }
        public WorkflowDefinition WorkflowDefinition { get; set; }
        public required long ProcessId { get; set; }
        public long CurrentStepId { get; set; }
        public WorkflowStep CurrentStep { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
