using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Optera.DataAccess;
using Optera.DTOs.City;
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
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        private readonly IMapper mapper;

        public CityRepository(DBContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(context, httpContextAccessor)
        {
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<PagedList<GetCityDto>>> GetCities(UserParams? userParams)
        {
            try
            {
                var cities = Get().ProjectTo<GetCityDto>(mapper.ConfigurationProvider);
                var result = await PagedList<GetCityDto>.CreatePageAsync(cities, userParams);
                return ServiceResponse<PagedList<GetCityDto>>.Succeeded(result, "Cities retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<PagedList<GetCityDto>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<GetCityDto>> CreateCity(CreateCityDto createCityDto)
        {
            try
            {
                var city = mapper.Map<City>(createCityDto);
                Add(city);
                var result = await SaveChangesAsync();
                if (result.Success)
                {
                    return ServiceResponse<GetCityDto>.Succeeded(mapper.Map<GetCityDto>(city), "City created successfully");
                }

                return ServiceResponse<GetCityDto>.Failed(null, "City creation failed!");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetCityDto>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<GetCityDto>> UpdateCity(UpdateCityDto updateCityDto)
        {
            try
            {
                var city = await GetByIdAsync(updateCityDto.Id);
                if (city != null)
                {
                    city.Name = updateCityDto.Name;
                    city.Name_OtherLanguage = updateCityDto.Name_OtherLanguage;
                    city.CountryId = updateCityDto.CountryId;
                    city.Status = updateCityDto.Status;

                    Update(city);
                    var result = await SaveChangesAsync();
                    if (result.Success)
                        return ServiceResponse<GetCityDto>.Succeeded(mapper.Map<GetCityDto>(city), "City updated successfully");
                    return ServiceResponse<GetCityDto>.Failed(null, "City update failed!");
                }
                else
                    return ServiceResponse<GetCityDto>.NotFound(null, "Can't find City with Id = " + updateCityDto.Id + " !");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetCityDto>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<PagedList<GetCityDto>>> Search(string value, UserParams? userParams)
        {
            try
            {
                var cities = Get().Where(p => p.Name.Contains(value) || 
                                            p.Name_OtherLanguage.Contains(value) ||
                                            p.Country.Name.Contains(value))
                    .ProjectTo<GetCityDto>(mapper.ConfigurationProvider);
                var result = await PagedList<GetCityDto>.CreatePageAsync(cities, userParams);
                return ServiceResponse<PagedList<GetCityDto>>.Succeeded(result, "Cities retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<PagedList<GetCityDto>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<ICollection<GetCityListDto>>> GetCitiesItemsList(long? countryId)
        {
            try
            {
                var cities = await GetByStatusAsync(Status.Active);
                if(countryId != null)
                    cities = cities.Where(x => x.CountryId == countryId).ToList();
                if (cities == null)
                    throw new Exception("Can't retrieve Cities List!");
                cities = cities.OrderBy(p => p.Name).ToList();
                return ServiceResponse<ICollection<GetCityListDto>>.Succeeded(mapper.Map<ICollection<GetCityListDto>>(cities), "Cities List retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<ICollection<GetCityListDto>>.Failed(null, ex.Message);
            }
        }

    }
}
