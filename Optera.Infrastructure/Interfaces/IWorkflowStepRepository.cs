using Optera.DTOs.Workflow;
using Optera.Utils.Pagination;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.Interfaces
{
    public interface IWorkflowStepRepository
    {
        public Task<ServiceResponse<PagedList<GetWorkflowStepDto>>> GetWorkflowSteps(UserParams? userParams, long id);
        public Task<ServiceResponse<GetWorkflowStepDto>> CreateWorkflowStep(CreateWorkflowStepDto createWorkflowStepDto);
        public Task<ServiceResponse<GetWorkflowStepDto>> UpdateWorkflowStep(UpdateWorkflowStepDto updateWorkflowStepDto);
    }
}
