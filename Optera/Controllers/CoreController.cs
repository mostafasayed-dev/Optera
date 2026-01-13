using Microsoft.AspNetCore.Mvc;
using Optera.Controllers.Base;
using Optera.DTOs.Core;
using Optera.DTOs.Country;
using Optera.Extensions;
using Optera.Infrastructure.Interfaces;
using Optera.Repositories;
using Optera.Utils.Models;
using Optera.Utils.Pagination;
using Optera.Utils.Response;

namespace Optera.Controllers
{
    public class CoreController : BaseApiController
    {
        private readonly IDataTableRepository dataTableRepository;
        private readonly IMenuItemRepository menuItemRepository;
        private readonly IComponentFormRepository componentFormRepository;

        public CoreController(IDataTableRepository dataTableRepository, 
                              IMenuItemRepository menuItemRepository,
                              IComponentFormRepository componentFormRepository)
        {
            this.dataTableRepository = dataTableRepository;
            this.menuItemRepository = menuItemRepository;
            this.componentFormRepository = componentFormRepository;
        }

        [HttpGet("datatable")]
        public async Task<ActionResult<ServiceResponse<GetDataTableDto>>> GetDataTableColumns([FromQuery] UserParams? userParams, string name)
        {
            var result = await dataTableRepository.GetDataTable(userParams, name);
            if (result.Status == ServiceStatus.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("menu-items")]
        public async Task<ActionResult<ServiceResponse<PagedList<GetMenuItemDto>>>> GetMenuItems()
        {
            var result = await menuItemRepository.GetMenuItems();

            if (result.Status == ServiceStatus.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("component-forms")]
        public async Task<ActionResult<ServiceResponse<GetDataTableDto>>> GetComponentForms([FromQuery] UserParams? userParams, string name)
        {
            var result = await componentFormRepository.GetComponentForms(userParams, name);
            if (result.Status == ServiceStatus.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
