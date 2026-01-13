using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.Workflow
{
    public class GetWorkflowDefinitionDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
