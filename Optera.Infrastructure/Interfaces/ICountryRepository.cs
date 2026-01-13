using Optera.DTOs.Country;
using Optera.Infrastructure.Interfaces.Base;
using Optera.Models;
using Optera.Utils.Pagination;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.Interfaces
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        public Task<ServiceResponse<GetCountryDto>> CreateCountry(CreateCountryDto createCountryDto);
        public Task<ServiceResponse<GetCountryDto>> UpdateCountry(UpdateCountryDto updateCountryDto);
        public Task<ServiceResponse<PagedList<GetCountryDto>>> GetCountries(UserParams? userParams);
        public Task<ServiceResponse<ICollection<string>>> GetCountriesSearchOptions();
        public Task<ServiceResponse<PagedList<GetCountryDto>>> Search(string value, UserParams? userParams);
        public Task<ServiceResponse<ICollection<GetCountryListDto>>> GetCountriesItemsList();
    }
}
