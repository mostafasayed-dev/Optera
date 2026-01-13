using AutoMapper;
using Optera.DTOs.Workflow;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.MappingProfiles
{
    public class WorkflowProfile : Profile
    {
        public WorkflowProfile()
        {
            CreateMap<WorkflowDefinition, GetWorkflowDefinitionDto>();
            CreateMap<WorkflowStep, GetWorkflowStepDto>();
            CreateMap<CreateWorkflowStepDto, WorkflowStep>();
            CreateMap<UpdateWorkflowStepDto, WorkflowStep>();
            CreateMap<WorkflowTransition, GetWorkflowTransitionDto>();
        }
    }
}
