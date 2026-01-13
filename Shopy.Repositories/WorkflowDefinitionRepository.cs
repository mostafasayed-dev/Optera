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
    public class WorkflowDefinitionRepository : BaseRepository<WorkflowDefinition>, IWorkflowDefinitionRepository
    {
        public readonly IMapper mapper;

        public WorkflowDefinitionRepository(DBContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(context, httpContextAccessor)
        {
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<PagedList<GetWorkflowDefinitionDto>>> GetWorkflowDefinitions(UserParams? userParams)
        {
            try
            {
                var definitions = await PagedList<GetWorkflowDefinitionDto>.CreatePageAsync(
                        Get().ProjectTo<GetWorkflowDefinitionDto>(mapper.ConfigurationProvider),
                        userParams);

                return ServiceResponse<PagedList<GetWorkflowDefinitionDto>>.Succeeded(definitions, "Workflow definitions retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<PagedList<GetWorkflowDefinitionDto>>.Failed(null, ex.Message);
            }
        }
    }
}
