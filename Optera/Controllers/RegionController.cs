using Microsoft.AspNetCore.Mvc;
using Optera.Controllers.Base;
using Optera.DTOs.City;
using Optera.DTOs.Region;
using Optera.Extensions;
using Optera.Infrastructure.Interfaces;
using Optera.Repositories;
using Optera.Utils.Models;
using Optera.Utils.Pagination;
using Optera.Utils.Response;

namespace Optera.Controllers
{
    public class RegionController : BaseApiController
    {
        private readonly IRegionRepository regionRepository;

        public RegionController(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<PagedList<GetRegionDto>>>> GetRegions([FromQuery] UserParams? userParams)
        {
            var result = await regionRepository.GetRegions(userParams);
            if (result.Status == ServiceStatus.Succeeded)
            {
                Response.AddPaginationHeader(result.Result.CurrentPage, result.Result.PageSize,
                                             result.Result.TotalCount, result.Result.TotalPages);
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetRegionDto>>> CreateRegion(CreateRegionDto createRegionDto)
        {
            var result = await regionRepository.CreateRegion(createRegionDto);
            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetRegionDto>>> UpdateCity(UpdateRegionDto updateRegionDto)
        {
            var result = await regionRepository.UpdateRegion(updateRegionDto);
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
            var result = await regionRepository.Search(option, userParams);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("items-list")]
        public async Task<ActionResult<ServiceResponse<ICollection<GetRegionListDto>>>> GetRegionsList()
        {
            var result = await regionRepository.GetRegionsItemsList(null);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("items-list/{cityId}")]
        public async Task<ActionResult<ServiceResponse<ICollection<GetRegionListDto>>>> GetRegionsList(long? cityId)
        {
            var result = await regionRepository.GetRegionsItemsList(cityId);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
