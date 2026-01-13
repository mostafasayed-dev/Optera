using Optera.Miscellaneous.DTOs.Country;
using Optera.Shared.Pagination.Pagination;
using Optera.Shared.Response;

namespace Optera.Miscellaneous.Services.Interfaces
{
    public interface ICountryService
    {
        public Task<ServiceResponse<GetCountry>> CreateCountry(CreateCountry createCountry);
        public Task<ServiceResponse<PagedList<GetCountry>>> GetCountries(UserParams? userParams);
        public Task<ServiceResponse<GetCountry>> GetCountry(Guid id);
        public Task<ServiceResponse<GetCountry>> UpdateCountry(Guid id, UpdateCountry updateCountry);
    }
}
