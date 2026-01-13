using Microsoft.AspNetCore.Mvc;
using Optera.Controllers.Base;
using Optera.DTOs.Workflow;
using Optera.Extensions;
using Optera.Infrastructure.Interfaces;
using Optera.Repositories;
using Optera.Utils.Pagination;
using Optera.Utils.Response;

namespace Optera.Controllers
{
    public class WorkflowController : BaseApiController
    {
        private readonly IWorkflowDefinitionRepository workflowDefinitionRepository;
        private readonly IWorkflowStepRepository workflowStepRepository;
        private readonly IWorkflowTransitionRepository workflowTransitionRepository;

        public WorkflowController(IWorkflowDefinitionRepository workflowDefinitionRepository,
                                  IWorkflowStepRepository workflowStepRepository,
                                  IWorkflowTransitionRepository workflowTransitionRepository)
        {
            this.workflowDefinitionRepository = workflowDefinitionRepository;
            this.workflowStepRepository = workflowStepRepository;
            this.workflowTransitionRepository = workflowTransitionRepository;
        }

        [HttpGet("definitions")]
        public async Task<ActionResult<ServiceResponse<PagedList<GetWorkflowDefinitionDto>>>> GetWorkflowDefinitions([FromQuery] UserParams userParams)
        {
            var result = await workflowDefinitionRepository.GetWorkflowDefinitions(userParams);
            if (result.Success)
            {
                Response.AddPaginationHeader(result.Result.CurrentPage, result.Result.PageSize,
                                             result.Result.TotalCount, result.Result.TotalPages);
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("steps/{id}")]
        public async Task<ActionResult<ServiceResponse<PagedList<GetWorkflowDefinitionDto>>>> GetWorkflowSteps([FromQuery] UserParams userParams, long id)
        {
            var result = await workflowStepRepository.GetWorkflowSteps(userParams, id);
            Response.AddPaginationHeader(result.Result.CurrentPage, result.Result.PageSize,
                                                         result.Result.TotalCount, result.Result.TotalPages);
            return Ok(result);
        }

        [HttpPost("step")]
        public async Task<ActionResult<ServiceResponse<GetWorkflowStepDto>>> CreateWorkflowStep(CreateWorkflowStepDto createWorkflowStepDto)
        {
            var result = await workflowStepRepository.CreateWorkflowStep(createWorkflowStepDto);
            return Ok(result);
        }

        [HttpPut("step")]
        public async Task<ActionResult<ServiceResponse<GetWorkflowStepDto>>> UpdateWorkflowStep(UpdateWorkflowStepDto updateWorkflowStepDto)
        {
            var result = await workflowStepRepository.UpdateWorkflowStep(updateWorkflowStepDto);
            return Ok(result);
        }

        [HttpGet("transitions/{id}")]
        public async Task<ActionResult<ServiceResponse<PagedList<GetWorkflowTransitionDto>>>> GetWorkflowTransitions([FromQuery] UserParams userParams, long id)
        {
            var result = await workflowTransitionRepository.GetWorkflowTransitions(userParams, id);
            Response.AddPaginationHeader(result.Result.CurrentPage, result.Result.PageSize,
                                                         result.Result.TotalCount, result.Result.TotalPages);
            return Ok(result);
        }
    }
}
