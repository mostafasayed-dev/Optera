using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.Workflow
{
    public class GetWorkflowStepDto
    {
        public long Id { get; set; }
        public long WorkflowDefinitionId { get; set; }
        public string WorkflowDefinitionName { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public bool IsFinal { get; set; }
        public string Status { get; set; }
    }
}
