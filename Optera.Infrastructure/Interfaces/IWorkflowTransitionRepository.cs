using Optera.DTOs.Workflow;
using Optera.Utils.Pagination;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.Interfaces
{
    public interface IWorkflowTransitionRepository
    {
        public Task<ServiceResponse<PagedList<GetWorkflowTransitionDto>>> GetWorkflowTransitions(UserParams? userParams, long id);
    }
}
