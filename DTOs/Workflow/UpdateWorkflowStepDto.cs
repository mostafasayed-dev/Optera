using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Optera.DTOs.Workflow
{
    public class UpdateWorkflowStepDto
    {
        public long Id { get; set; }
        public required long WorkflowDefinitionId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }
        public required int Order { get; set; }
        public required bool IsFinal { get; set; }
        public required string Status { get; set; }
    }
}
