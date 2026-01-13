using Microsoft.AspNetCore.Mvc;
using Optera.Query.Controllers.Base;
using Optera.Query.DTOs.Miscellaneous;
using Optera.Query.Services.Interfaces;
using Optera.Shared.Pagination.Extensions;
using Optera.Shared.Pagination.Pagination;
using Optera.Shared.Response;

namespace Optera.Query.Controllers
{
    public class CountriesController : BaseApiController
    {
        private readonly ICountryService countryService;

        public CountriesController(ICountryService countryService) 
        {
            this.countryService = countryService;
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
    }
}
