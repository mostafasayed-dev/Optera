using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Optera.Configuration.Controllers.Base;
using Optera.Configuration.DTOs;
using Optera.Configuration.Repositories;
using Optera.Configuration.Repositories.Interfaces;
using Optera.Configuration.Services.Interfaces;
using Optera.Shared.Pagination.Extensions;
using Optera.Shared.Pagination.Pagination;
using Optera.Shared.Response;

namespace Optera.Configuration.Controllers
{
    public class ConfigurationController : BaseApiController
    {
        private readonly IConfigurationService configurationService;

        public ConfigurationController(IConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        [HttpGet("components")]
        public async Task<ActionResult<ServiceResponse<PagedList<GetComponentDto>>>> GetComponents([FromQuery] UserParams? userParams)
        {
            var result = await configurationService.GetComponents(userParams);
            if (result.Status == ResponseStatus.SUCCEEDED)
            {
                Response.AddPaginationHeader(result.Result.CurrentPage, result.Result.PageSize,
                                             result.Result.TotalCount, result.Result.TotalPages);
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("menu-items")]
        public async Task<ActionResult<ServiceResponse<PagedList<GetMenuItemDto>>>> GetMenuItems()
        {
            var result = await configurationService.GetMenuItems();

            if (result.Status == ResponseStatus.SUCCEEDED)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("datatable")]
        public async Task<ActionResult<ServiceResponse<GetDataTableDto>>> GetDataTableColumns(string name)
        {
            var result = await configurationService.GetDataTable(name);
            if (result.Status == ResponseStatus.SUCCEEDED)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
