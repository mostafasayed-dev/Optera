using AutoMapper;
using AutoMapper.QueryableExtensions;
using MassTransit;
using MassTransit.Transports;
using Optera.Miscellaneous.DTOs.Country;
using Optera.Miscellaneous.Models;
using Optera.Miscellaneous.Reopositories.Interfaces;
using Optera.Miscellaneous.Services.Interfaces;
using Optera.Shared.Core.Identity;
using Optera.Shared.Identity;
using Optera.Shared.Messaging.Events.Employees;
using Optera.Shared.Messaging.Events.Miscellaneous;
using Optera.Shared.Pagination.Pagination;
using Optera.Shared.Response;

namespace Optera.Miscellaneous.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;
        private readonly IMapper mapper;
        private readonly ICurrentUserContext currentUserContext;
        private readonly IPublishEndpoint publishEndpoint;

        public CountryService(ICountryRepository countryRepository, 
            IMapper mapper,
            ICurrentUserContext currentUserContext,
            IPublishEndpoint publishEndpoint)
        {
            this.countryRepository = countryRepository;
            this.mapper = mapper;
            this.currentUserContext = currentUserContext;
            this.publishEndpoint = publishEndpoint;
        }

        public async Task<ServiceResponse<GetCountry>> CreateCountry(CreateCountry createCountry)
        {
            try
            {
                var country = mapper.Map<Country>(createCountry);
                await countryRepository.AddAsync(country);

                //var @event = new CountryCreated(
                //        country.Id,
                //        country.Name,
                //        country.Name_OtherLanguage,
                //        country.ISOCode
                //    )
                //{
                //    Username = currentUserContext.UserName!
                //};

                //await publishEndpoint.Publish(@event);

                var result = await countryRepository.SaveChangesAsync();
                if (!result)
                    return ServiceResponse<GetCountry>.Failed(null, "Country creation failed!");

                return ServiceResponse<GetCountry>.Succeeded(mapper.Map<GetCountry>(country), "Country created successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetCountry>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<PagedList<GetCountry>>> GetCountries(UserParams? userParams)
        {
            try
            {
                var result = this.countryRepository.GetAll()
                    .ProjectTo<GetCountry>(mapper.ConfigurationProvider);

                var list = await PagedList<GetCountry>.CreatePageAsync(result, userParams);

                return ServiceResponse<PagedList<GetCountry>>.Succeeded(list, "Countries retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<PagedList<GetCountry>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<GetCountry>> GetCountry(long id)
        {
            try
            {
                var country = await this.countryRepository.GetByIdAsync(id);

                if(country == null)
                    return ServiceResponse<GetCountry>.NotFound(null, "Country not found!");

                return ServiceResponse<GetCountry>.Succeeded(mapper.Map<GetCountry>(country), "Countries retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetCountry>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<GetCountry>> UpdateCountry(long id, UpdateCountry updateCountry)
        {
            try
            {
                var country = await this.countryRepository.GetByIdAsync(id);

                if (country == null)
                    return ServiceResponse<GetCountry>.NotFound(null, "Country not found!");

                var result = mapper.Map(updateCountry, country);
                this.countryRepository.Update(result);

                //var @event = new CountryUpdated(
                //    country.Id,
                //    country.Name,
                //    country.Name_OtherLanguage,
                //    country.ISOCode
                //)
                //{
                //    Username = currentUserContext.UserName!
                //};

                //await publishEndpoint.Publish(@event);

                await this.countryRepository.SaveChangesAsync();

                return ServiceResponse<GetCountry>.Succeeded(mapper.Map<GetCountry>(country), "Country updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetCountry>.Failed(null, ex.Message);
            }
        }
    }
}
