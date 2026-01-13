using AutoMapper;
using Optera.DTOs.Country;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.MappingProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CreateCountryDto, Country>();
            CreateMap<Country, GetCountryDto>();
            CreateMap<Country, GetCountryListDto>().ForMember(dest => dest.Value, opt => opt.MapFrom(p => p.Id))
                                         .ForMember(dest => dest.Text, opt => opt.MapFrom(p => p.Name));
        }
    }
}
