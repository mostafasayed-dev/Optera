using Microsoft.AspNetCore.Mvc;
using Optera.Controllers.Base;
using Optera.DTOs.Country;
using Optera.Extensions;
using Optera.Infrastructure.Interfaces;
using Optera.Repositories;
using Optera.Utils.Models;
using Optera.Utils.Pagination;
using Optera.Utils.Response;

namespace Optera.Controllers
{
    public class CountryController : BaseApiController
    {
        private readonly ICountryRepository countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCountryDto>>> CreateCountry(CreateCountryDto createCountryDto)
        {
            var result = await countryRepository.CreateCountry(createCountryDto);
            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCountryDto>>> UpdateCountry(UpdateCountryDto updateCountryDto)
        {
            var result = await countryRepository.UpdateCountry(updateCountryDto);
            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<PagedList<GetCountryDto>>>> GetCountries([FromQuery] UserParams? userParams)
        {
            var result = await countryRepository.GetCountries(userParams);
            if (result.Status == ServiceStatus.Succeeded)
            {
                Response.AddPaginationHeader(result.Result.CurrentPage, result.Result.PageSize,
                                             result.Result.TotalCount, result.Result.TotalPages);
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("items-list")]
        public async Task<ActionResult<ServiceResponse<ICollection<GetCountryListDto>>>> GetCategoriesList()
        {
            var result = await countryRepository.GetCountriesItemsList();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("search-options")]
        public async Task<ActionResult<ICollection<string>>> GetCountriesSearchOptions()
        {
            var result = await countryRepository.GetCountriesSearchOptions();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult<PagedList<GetCountryDto>>> Search([FromQuery] string option, [FromQuery] UserParams userParams)
        {
            var result = await countryRepository.Search(option, userParams);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
