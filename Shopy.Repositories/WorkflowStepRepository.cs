using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Optera.DataAccess;
using Optera.DTOs.Quotation;
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
    public class WorkflowStepRepository : BaseRepository<WorkflowStep>, IWorkflowStepRepository
    {
        private readonly IMapper mapper;

        public WorkflowStepRepository(DBContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(context, httpContextAccessor)
        {
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<PagedList<GetWorkflowStepDto>>> GetWorkflowSteps(UserParams? userParams, long id)
        {
            try
            {
                var steps = await PagedList<GetWorkflowStepDto>.CreatePageAsync(
                        Get().Where(x => x.WorkflowDefinitionId == id).ProjectTo<GetWorkflowStepDto>(mapper.ConfigurationProvider),
                        userParams);

                return ServiceResponse<PagedList<GetWorkflowStepDto>>.Succeeded(steps, "Workflow steps retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<PagedList<GetWorkflowStepDto>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<GetWorkflowStepDto>> CreateWorkflowStep(CreateWorkflowStepDto createWorkflowStepDto)
        {
            try
            {
                var workflowStep = mapper.Map<WorkflowStep>(createWorkflowStepDto);
                if(workflowStep == null)
                    return ServiceResponse<GetWorkflowStepDto>.Failed(null, "Workflow step creation failed.");

                var steps = await GetAsync();
                if(steps != null && steps.Count > 0)
                {
                    var step = steps.Where(x => x.WorkflowDefinitionId == workflowStep.WorkflowDefinitionId 
                                && x.Order == workflowStep.Order).FirstOrDefault();
                    if (step != null)
                        return ServiceResponse<GetWorkflowStepDto>.AlreadyExists(null, "Workflow step '" + step.Name + "' with the same order already exists!");
                }

                Add(workflowStep);
                var result = await SaveChangesAsync();
                if(!result.Success)
                    return ServiceResponse<GetWorkflowStepDto>.Failed(null, "Workflow step creation failed.");

                return ServiceResponse<GetWorkflowStepDto>.Succeeded(mapper.Map<GetWorkflowStepDto>(workflowStep), "Workflow step created successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetWorkflowStepDto>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<GetWorkflowStepDto>> UpdateWorkflowStep(UpdateWorkflowStepDto updateWorkflowStepDto)
        {
            try
            {
                var workflowStep = await GetByIdAsync(updateWorkflowStepDto.Id);
                if(workflowStep == null)
                    return ServiceResponse<GetWorkflowStepDto>.NotFound(null, "Workflow step not found!");

                var steps = await GetAsync();
                if (steps != null && steps.Count > 0)
                {
                    var step = steps.Where(x => x.WorkflowDefinitionId == updateWorkflowStepDto.WorkflowDefinitionId
                                && x.Id != updateWorkflowStepDto.Id
                                && x.Order == updateWorkflowStepDto.Order).FirstOrDefault();
                    if (step != null)
                        return ServiceResponse<GetWorkflowStepDto>.AlreadyExists(null, "Workflow step '" + step.Name + "' with the same order already exists!");
                }

                mapper.Map(updateWorkflowStepDto, workflowStep);
                Update(workflowStep);
                var result = await SaveChangesAsync();
                if (!result.Success)
                    return ServiceResponse<GetWorkflowStepDto>.Failed(null, "Workflow step update failed!");

                return ServiceResponse<GetWorkflowStepDto>.Succeeded(mapper.Map<GetWorkflowStepDto>(workflowStep), "Workflow step updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetWorkflowStepDto>.Failed(null, ex.Message);
            }
        }
    }
}
