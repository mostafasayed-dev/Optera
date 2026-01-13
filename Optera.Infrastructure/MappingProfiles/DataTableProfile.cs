using AutoMapper;
using Optera.DTOs.Core;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.MappingProfiles
{
    public class DataTableProfile : Profile
    {
        public DataTableProfile()
        {
            CreateMap<DataTable, GetDataTableDto>().ForMember(dest => dest.Columns, opt => opt.MapFrom(p => p.DataTableColumns));
        }
    }
}
