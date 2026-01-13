using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.Workflow
{
    public class GetWorkflowTransitionDto
    {
        public long Id { get; set; }
        public long FromStepId { get; set; }
        public string FromStepName { get; set; }
        public long ToStepId { get; set; }
        public string ToStepName { get; set; }
        public string ActionName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public long WorkflowDefinitionId { get; set; }
        public string WorkflowDefinitionName { get; set; }
        public string TargetStatus { get; set; }
        public string Status { get; set; }
    }
}
