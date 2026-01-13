using Optera.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Models
{
    public class WorkflowTransition : BaseModel
    {
        public long FromStepId { get; set; }
        public WorkflowStep FromStep { get; set; }
        public long ToStepId { get; set; }
        public WorkflowStep ToStep { get; set; }
        public required string ActionName { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public long WorkflowDefinitionId { get; set; }
        public WorkflowDefinition WorkflowDefinition { get; set; }
        public string TargetStatus { get; set; }
    }
}
