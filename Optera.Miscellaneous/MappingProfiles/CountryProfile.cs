using AutoMapper;
using Optera.Miscellaneous.DTOs.Country;
using Optera.Miscellaneous.Models;

namespace Optera.Miscellaneous.MappingProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CreateCountry, Country>();
            CreateMap<UpdateCountry, Country>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Country, GetCountry>();
        }
    }
}
