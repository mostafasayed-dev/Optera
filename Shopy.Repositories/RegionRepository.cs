using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Optera.DataAccess;
using Optera.DTOs.City;
using Optera.DTOs.Region;
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
    public class RegionRepository : BaseRepository<Region>, IRegionRepository
    {
        private readonly IMapper mapper;
        private readonly DBContext context;

        public RegionRepository(DBContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(context, httpContextAccessor)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<ServiceResponse<PagedList<GetRegionDto>>> GetRegions(UserParams? userParams)
        {
            try
            {
                var regions = Get().ProjectTo<GetRegionDto>(mapper.ConfigurationProvider);
                var result = await PagedList<GetRegionDto>.CreatePageAsync(regions, userParams);
                return ServiceResponse<PagedList<GetRegionDto>>.Succeeded(result, "Regions retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<PagedList<GetRegionDto>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<GetRegionDto>> CreateRegion(CreateRegionDto createRegionDto)
        {
            try
            {
                var region = mapper.Map<Region>(createRegionDto);
                Add(region);
                var result = await SaveChangesAsync();
                if (result.Success)
                {
                    return ServiceResponse<GetRegionDto>.Succeeded(mapper.Map<GetRegionDto>(region), "Region created successfully.");
                }

                return ServiceResponse<GetRegionDto>.Failed(null, "Region creation failed!");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetRegionDto>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<GetRegionDto>> UpdateRegion(UpdateRegionDto updateRegionDto)
        {
            try
            {
                var region = await GetByIdAsync(updateRegionDto.Id);
                if (region != null)
                {
                    region.Name = updateRegionDto.Name;
                    region.Name_OtherLanguage = updateRegionDto.Name_OtherLanguage;
                    region.CityId = updateRegionDto.CityId;
                    region.Status = updateRegionDto.Status;

                    Update(region);
                    var result = await SaveChangesAsync();
                    if (result.Success)
                        return ServiceResponse<GetRegionDto>.Succeeded(mapper.Map<GetRegionDto>(region), "Region updated successfully.");
                    return ServiceResponse<GetRegionDto>.Failed(null, "Region update failed!");
                }
                else
                    return ServiceResponse<GetRegionDto>.NotFound(null, "Can't find City with Id = " + updateRegionDto.Id + " !");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetRegionDto>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<PagedList<GetRegionDto>>> Search(string value, UserParams? userParams)
        {
            try
            {
                var cities = Get().Where(p => p.Name.Contains(value) ||
                                            p.Name_OtherLanguage.Contains(value) ||
                                            p.City.Name.Contains(value) || 
                                            p.City.Country.Name.Contains(value))
                    .ProjectTo<GetRegionDto>(mapper.ConfigurationProvider);
                var result = await PagedList<GetRegionDto>.CreatePageAsync(cities, userParams);
                return ServiceResponse<PagedList<GetRegionDto>>.Succeeded(result, "Regions retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<PagedList<GetRegionDto>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<ICollection<GetRegionListDto>>> GetRegionsItemsList(long? cityId)
        {
            try
            {
                var regions = await GetByStatusAsync(Status.Active);
                if (cityId != null)
                    regions = regions.Where(x => x.CityId == cityId).ToList();
                if (regions == null)
                    throw new Exception("Can't retrieve Cities List!");
                regions = regions.OrderBy(p => p.Name).ToList();
                return ServiceResponse<ICollection<GetRegionListDto>>.Succeeded(mapper.Map<ICollection<GetRegionListDto>>(regions), "Regions list retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<ICollection<GetRegionListDto>>.Failed(null, ex.Message);
            }
        }

    }
}
