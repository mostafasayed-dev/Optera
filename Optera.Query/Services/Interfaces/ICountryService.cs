using Optera.Query.DTOs.Miscellaneous;
using Optera.Shared.Pagination.Pagination;
using Optera.Shared.Response;

namespace Optera.Query.Services.Interfaces
{
    public interface ICountryService
    {
        public Task<ServiceResponse<PagedList<GetCountry>>> GetCountries(UserParams? userParams);
    }
}
