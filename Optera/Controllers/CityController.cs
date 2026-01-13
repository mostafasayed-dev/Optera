using Microsoft.AspNetCore.Mvc;
using Optera.Controllers.Base;
using Optera.DTOs.City;
using Optera.DTOs.Country;
using Optera.Extensions;
using Optera.Infrastructure.Interfaces;
using Optera.Repositories;
using Optera.Utils.Models;
using Optera.Utils.Pagination;
using Optera.Utils.Response;

namespace Optera.Controllers
{
    public class CityController : BaseApiController
    {
        readonly ICityRepository cityRepository;
        public CityController(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<PagedList<GetCityDto>>>> GetCities([FromQuery] UserParams? userParams)
        {
            var result = await cityRepository.GetCities(userParams);
            if (result.Status == ServiceStatus.Succeeded)
            {
                Response.AddPaginationHeader(result.Result.CurrentPage, result.Result.PageSize,
                                             result.Result.TotalCount, result.Result.TotalPages);
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCityDto>>> CreateCity(CreateCityDto createCityDto)
        {
            var result = await cityRepository.CreateCity(createCityDto);
            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCityDto>>> UpdateCity(UpdateCityDto updateCityDto)
        {
            var result = await cityRepository.UpdateCity(updateCityDto);
            if (!result.Success)
            {
                if(result.Status == ServiceStatus.NotFound)
                    return NotFound(result);
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult<PagedList<GetCityDto>>> Search([FromQuery] string option, [FromQuery] UserParams userParams)
        {
            var result = await cityRepository.Search(option, userParams);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("items-list")]
        public async Task<ActionResult<ServiceResponse<ICollection<GetCityListDto>>>> GetCitiesList()
        {
            var result = await cityRepository.GetCitiesItemsList(null);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("items-list/{countryId}")]
        public async Task<ActionResult<ServiceResponse<ICollection<GetCityListDto>>>> GetCitiesList(long countryId)
        {
            var result = await cityRepository.GetCitiesItemsList(countryId);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
