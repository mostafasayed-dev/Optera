using AutoMapper;
using AutoMapper.QueryableExtensions;
using Optera.Query.DTOs.Miscellaneous;
using Optera.Query.Repositories.Interfaces;
using Optera.Query.Services.Interfaces;
using Optera.Shared.Pagination.Pagination;
using Optera.Shared.Response;

namespace Optera.Query.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;
        private IMapper mapper;

        public CountryService(ICountryRepository countryRepository,
            IMapper mapper)
        {
            this.countryRepository = countryRepository;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<PagedList<GetCountry>>> GetCountries(UserParams? userParams)
        {
            try
            {
                var result = this.countryRepository.GetAll()
                    .Where(x => userParams == null || string.IsNullOrEmpty(userParams.SearchKey)
                        || x.Name.Contains(userParams.SearchKey)
                        || x.Name_OtherLanguage.Contains(userParams.SearchKey)
                        || x.ISOCode.Contains(userParams.SearchKey)
                        || x.Status.Contains(userParams.SearchKey))
                    .ProjectTo<GetCountry>(mapper.ConfigurationProvider);

                var list = await PagedList<GetCountry>.CreatePageAsync(result, userParams);

                return ServiceResponse<PagedList<GetCountry>>.Succeeded(list, "Countries retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<PagedList<GetCountry>>.Failed(null, ex.Message);
            }
        }
    }
}
