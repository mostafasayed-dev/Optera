using AutoMapper;
using Optera.DTOs.User;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Optera.Infrastructure.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetUserDTO>()
                .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => src.EmailConfirmed ? 1 : 0))
                .ForMember(dest => dest.Locked, opt => opt.MapFrom(src => src.Locked ? 1 : 0))
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.Name));

            CreateMap<User, RegisterDTO>();
        }
    }
}
