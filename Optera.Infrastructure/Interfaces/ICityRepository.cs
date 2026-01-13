using Optera.DTOs.City;
using Optera.DTOs.Country;
using Optera.Utils.Pagination;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.Interfaces
{
    public interface ICityRepository
    {
        public Task<ServiceResponse<PagedList<GetCityDto>>> GetCities(UserParams? userParams);
        public Task<ServiceResponse<GetCityDto>> CreateCity(CreateCityDto createCityDto);
        public Task<ServiceResponse<GetCityDto>> UpdateCity(UpdateCityDto updateCityDto);
        public Task<ServiceResponse<PagedList<GetCityDto>>> Search(string value, UserParams? userParams);
        public Task<ServiceResponse<ICollection<GetCityListDto>>> GetCitiesItemsList(long? countryId);
    }
}
