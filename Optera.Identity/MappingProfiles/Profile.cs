using Microsoft.AspNetCore.Identity;
using Optera.Identity.DTOs;

namespace Optera.Identity.MappingProfiles
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<IdentityUser, GetUserDto>();
            CreateMap<IdentityUser, RegisterDto>();
            CreateMap<IdentityRole, GetRoleDto>();
            CreateMap<IdentityRole, GetRoleListDto>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(p => p.Name))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(p => p.Name));
        }
    }
}
