using Microsoft.AspNetCore.Mvc;
using Optera.Miscellaneous.Controllers.Base;
using Optera.Miscellaneous.DTOs.Country;
using Optera.Miscellaneous.Services.Interfaces;
using Optera.Shared.Pagination.Extensions;
using Optera.Shared.Pagination.Pagination;
using Optera.Shared.Response;

namespace Optera.Miscellaneous.Controllers
{
    public class CountriesController : BaseApiController
    {
        private readonly ICountryService countryService;

        public CountriesController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCountry>>> CreateCountry([FromBody] CreateCountry createCountry)
        {
            var result = await countryService.CreateCountry(createCountry);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCountry>>> CreateCountry(Guid id, [FromBody] UpdateCountry updateCountry)
        {
            var result = await countryService.UpdateCountry(id, updateCountry);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<PagedList<GetCountry>>>> GetCountries([FromQuery] UserParams? userParams)
        {
            var result = await countryService.GetCountries(userParams);
            if (result.Status == ResponseStatus.SUCCEEDED)
            {
                Response.AddPaginationHeader(result.Result.CurrentPage, result.Result.PageSize,
                                             result.Result.TotalCount, result.Result.TotalPages);
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCountry>>> GetCountry(Guid id)
        {
            var result = await countryService.GetCountry(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
