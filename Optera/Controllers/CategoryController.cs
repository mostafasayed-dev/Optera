using Microsoft.AspNetCore.Mvc;
using Optera.Controllers.Base;
using Optera.DTOs.Category;
using Optera.DTOs.City;
using Optera.Extensions;
using Optera.Infrastructure.Interfaces;
using Optera.Repositories;
using Optera.Utils.Models;
using Optera.Utils.Pagination;
using Optera.Utils.Response;

namespace Optera.Controllers
{
    public class CategoryController : BaseApiController
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<PagedList<GetCategoryDto>>>> GetCategories([FromQuery] UserParams? userParams)
        {
            var result = await categoryRepository.GetCategories(userParams);
            if (result.Status == ServiceStatus.Succeeded)
            {
                Response.AddPaginationHeader(result.Result.CurrentPage, result.Result.PageSize,
                                             result.Result.TotalCount, result.Result.TotalPages);
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult<PagedList<GetCategoryDto>>> Search([FromQuery] string option, [FromQuery] UserParams userParams)
        {
            var result = await categoryRepository.Search(option, userParams);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
