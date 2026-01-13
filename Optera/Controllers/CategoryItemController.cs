using Microsoft.AspNetCore.Mvc;
using Optera.Controllers.Base;
using Optera.DTOs.CategoryItem;
using Optera.DTOs.City;
using Optera.DTOs.Region;
using Optera.Extensions;
using Optera.Infrastructure.Interfaces;
using Optera.Repositories;
using Optera.Services;
using Optera.Utils.Helper;
using Optera.Utils.Models;
using Optera.Utils.Pagination;
using Optera.Utils.Response;

namespace Optera.Controllers
{
    public class CategoryItemController : BaseApiController
    {
        private readonly ICategoryItemRepository categoryItemRepository;
        public CategoryItemController(ICategoryItemRepository categoryItemRepository)
        {
            this.categoryItemRepository = categoryItemRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<PagedList<GetCategoryItemDto>>>> GetCategoryItems(long id, [FromQuery] UserParams? userParams)
        {
            var result = await categoryItemRepository.GetCategoryItems(id, userParams);
            if (result.Status == ServiceStatus.Succeeded)
            {
                Response.AddPaginationHeader(result.Result.CurrentPage, result.Result.PageSize,
                                             result.Result.TotalCount, result.Result.TotalPages);
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("list/{categoryId}")]
        public async Task<ActionResult<ServiceResponse<ICollection<GetCategoryItemListDto>>>> GetCategoryItemsList(long categoryId)
        {
            var result = await categoryItemRepository.GetCategoryItemsList(categoryId);
            if (result.Status == ServiceStatus.Succeeded)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCategoryItemDto>>> CreateCategoryItem(CreateCategoryItemDto createCategoryItemDto)
        {
            var result = await categoryItemRepository.CreateCategoryItem(createCategoryItemDto);
            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCategoryItemDto>>> UpdateCity(UpdateCategoryItemDto updateCategoryItemDto)
        {
            var result = await categoryItemRepository.UpdateCategoryItem(updateCategoryItemDto);
            if (!result.Success)
            {
                if (result.Status == ServiceStatus.NotFound)
                    return NotFound(result);
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult<PagedList<GetCityDto>>> Search([FromQuery] string option, [FromQuery] UserParams userParams)
        {
            var result = await categoryItemRepository.Search(option, userParams);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
