using Optera.DTOs.Workflow;
using Optera.Utils.Pagination;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.Interfaces
{
    public interface IWorkflowDefinitionRepository
    {
        public Task<ServiceResponse<PagedList<GetWorkflowDefinitionDto>>> GetWorkflowDefinitions(UserParams? userParams);
    }
}
