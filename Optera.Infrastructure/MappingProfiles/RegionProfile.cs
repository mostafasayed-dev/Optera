using AutoMapper;
using Optera.DTOs.City;
using Optera.DTOs.Country;
using Optera.DTOs.Region;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.MappingProfiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, GetRegionDto>()
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.City.Country.Name));
            CreateMap<CreateRegionDto, Region>();
            CreateMap<UpdateRegionDto, Region>();
            CreateMap<Region, GetRegionListDto>().ForMember(dest => dest.Value, opt => opt.MapFrom(p => p.Id))
                             .ForMember(dest => dest.Text, opt => opt.MapFrom(p => p.Name));
        }
    }
}
