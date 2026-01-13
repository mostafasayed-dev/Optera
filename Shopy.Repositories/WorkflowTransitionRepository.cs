using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Optera.DataAccess;
using Optera.DTOs.Workflow;
using Optera.Infrastructure.Interfaces;
using Optera.Models;
using Optera.Repositories.Base;
using Optera.Utils.Pagination;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Repositories
{
    public class WorkflowTransitionRepository : BaseRepository<WorkflowTransition>, IWorkflowTransitionRepository
    {
        private readonly IMapper mapper;

        public WorkflowTransitionRepository(DBContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(context, httpContextAccessor)
        {
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<PagedList<GetWorkflowTransitionDto>>> GetWorkflowTransitions(UserParams? userParams, long id)
        {
            try
            {
                var transitions = await PagedList<GetWorkflowTransitionDto>.CreatePageAsync(
                        Get().Where(x => x.WorkflowDefinitionId == id).ProjectTo<GetWorkflowTransitionDto>(mapper.ConfigurationProvider),
                        userParams);

                return ServiceResponse<PagedList<GetWorkflowTransitionDto>>.Succeeded(transitions, "Workflow transitions retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<PagedList<GetWorkflowTransitionDto>>.Failed(null, ex.Message);
            }
        }
    }
}
