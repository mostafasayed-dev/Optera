using Optera.Configuration.DTOs;
using Optera.Configuration.Models;

namespace Optera.Configuration.MappingProfiles
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<Component, GetComponentDto>();
            CreateMap<MenuItem, GetMenuItemDto>();
            CreateMap<DataTable, GetDataTableDto>().ForMember(dest => dest.Columns, opt => opt.MapFrom(p => p.DataTableColumns));
            CreateMap<DataTableColumn, GetDataTableColumnDto>();
        }
    }
}
