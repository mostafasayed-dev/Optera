using AutoMapper;
using Optera.DTOs.Role;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.MappingProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, GetRoleDto>();
            CreateMap<Role, GetRoleListDto>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(p => p.Name))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(p => p.Name));
        }
    }
}
