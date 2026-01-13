using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Optera.DataAccess;
using Optera.DTOs.Country;
using Optera.Infrastructure.Interfaces;
using Optera.Models;
using Optera.Repositories.Base;
using Optera.Utils.Models;
using Optera.Utils.Pagination;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        private readonly DBContext dbContext;
        private readonly IMapper mapper;

        public CountryRepository(DBContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(context, httpContextAccessor)
        {
            this.dbContext = context;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<GetCountryDto>> CreateCountry(CreateCountryDto createCountryDto)
        {
            try
            {
                var country = mapper.Map<Country>(createCountryDto);
                Add(country);
                var result = await SaveChangesAsync();
                if (result.Success)
                {
                    return ServiceResponse<GetCountryDto>.Succeeded(mapper.Map<GetCountryDto>(country), "Country created successfully");
                }

                return ServiceResponse<GetCountryDto>.Failed(null, "Country creation failed!");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetCountryDto>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<PagedList<GetCountryDto>>> GetCountries(UserParams? userParams)
        {
            try
            {
                var countries = Get().ProjectTo<GetCountryDto>(mapper.ConfigurationProvider);
                var result = await PagedList<GetCountryDto>.CreatePageAsync(countries, userParams);
                return ServiceResponse<PagedList<GetCountryDto>>.Succeeded(result, "Countries retrived successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<PagedList<GetCountryDto>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<ICollection<GetCountryListDto>>> GetCountriesItemsList()
        {
            try
            {
                var countries = await GetByStatusAsync(Status.Active);
                if (countries == null)
                    throw new Exception("Can't retrieve Countries List!");
                countries = countries.OrderBy(p => p.Name).ToList();
                return ServiceResponse<ICollection<GetCountryListDto>>.Succeeded(mapper.Map<ICollection<GetCountryListDto>>(countries), "Countries List retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<ICollection<GetCountryListDto>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<ICollection<string>>> GetCountriesSearchOptions()
        {
            try
            {
                List<string> optionsList = new List<string>();

                optionsList = await Get().OrderBy(p => p.Name).Select(x => x.Name).ToListAsync();
                optionsList.AddRange(await Get().OrderBy(p => p.Name_OtherLanguage).Select(x => x.Name_OtherLanguage).ToListAsync());

                return ServiceResponse<ICollection<string>>.Succeeded(optionsList, "Countries Search Options retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<ICollection<string>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<PagedList<GetCountryDto>>> Search(string value, UserParams? userParams)
        {
            try
            {
                var countries = Get().Where(p => p.Name.Contains(value) || p.Name_OtherLanguage.Contains(value)).ProjectTo<GetCountryDto>(mapper.ConfigurationProvider);
                var result = await PagedList<GetCountryDto>.CreatePageAsync(countries, userParams);
                return ServiceResponse<PagedList<GetCountryDto>>.Succeeded(result, "Countries retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<PagedList<GetCountryDto>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<GetCountryDto>> UpdateCountry(UpdateCountryDto updateCountryDto)
        {
            try
            {
                var country = await GetByIdAsync(updateCountryDto.Id);
                if(country != null)
                {
                    country.Name = updateCountryDto.Name;
                    country.Name_OtherLanguage = updateCountryDto.Name_OtherLanguage;
                    country.ISOCode = updateCountryDto.ISOCode;
                    country.Status = updateCountryDto.Status;

                    Update(country);
                    var result = await SaveChangesAsync();
                    if (result.Success)
                        return ServiceResponse<GetCountryDto>.Succeeded(mapper.Map<GetCountryDto>(country), "Country updated successfully");
                    return ServiceResponse<GetCountryDto>.Failed(null, "Country update failed!");
                }
                else
                    return ServiceResponse<GetCountryDto>.NotFound(null, "Can't find Country with Id = " + updateCountryDto.Id + " !");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetCountryDto>.Failed(null, ex.Message);
            }
        }
    }
}
