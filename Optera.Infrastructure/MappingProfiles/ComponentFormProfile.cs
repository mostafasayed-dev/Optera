using AutoMapper;
using Optera.DTOs.Core;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.MappingProfiles
{
    public class ComponentFormProfile : Profile
    {
        public ComponentFormProfile()
        {
            CreateMap<ComponentForm, GetComponentFormDto>();
        }
    }
}
