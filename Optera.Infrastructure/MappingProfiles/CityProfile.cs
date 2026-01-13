using AutoMapper;
using Optera.DTOs.City;
using Optera.DTOs.Country;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.MappingProfiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, GetCityDto>();
            CreateMap<CreateCityDto, City>();
            CreateMap<UpdateCityDto, City>();
            CreateMap<City, GetCityListDto>().ForMember(dest => dest.Value, opt => opt.MapFrom(p => p.Id))
                             .ForMember(dest => dest.Text, opt => opt.MapFrom(p => p.Name));
        }
    }
}
