using AutoMapper;
using Optera.DTOs.Core;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.MappingProfiles
{
    public class AuthorizationProfile : Profile
    {
        public AuthorizationProfile()
        {
            CreateMap<Authorization, GetAuthorizationDto>();
        }
    }
}
