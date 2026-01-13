using AutoMapper;
using Optera.Query.DTOs.Miscellaneous;
using Optera.Query.Models;

namespace Optera.Query.MappingProfiles
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<Country, GetCountry>();
        }
    }
}
