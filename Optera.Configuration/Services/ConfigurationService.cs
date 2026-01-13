using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Optera.Configuration.DTOs;
using Optera.Configuration.Repositories.Interfaces;
using Optera.Configuration.Services.Interfaces;
using Optera.Shared.Pagination.Pagination;
using Optera.Shared.Response;

namespace Optera.Configuration.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IComponentRepository componentRepository;
        private readonly IMenuItemRepository menuItemRepository;
        private readonly IDataTableRepository dataTableRepository;
        private readonly IMapper mapper;

        public ConfigurationService(IComponentRepository componentRepository,
            IMenuItemRepository menuItemRepository,
            IDataTableRepository dataTableRepository,
            IMapper mapper) 
        {
            this.componentRepository = componentRepository;
            this.menuItemRepository = menuItemRepository;
            this.dataTableRepository = dataTableRepository;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<PagedList<GetComponentDto>>> GetComponents(UserParams? userParams)
        {
            try
            {
                var result = this.componentRepository.GetAll()
                    .ProjectTo<GetComponentDto>(mapper.ConfigurationProvider);

                var list = await PagedList<GetComponentDto>.CreatePageAsync(result, userParams);

                return ServiceResponse<PagedList<GetComponentDto>>.Succeeded(list, "Components retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<PagedList<GetComponentDto>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<List<GetMenuItemDto>>> GetMenuItems()
        {
            try
            {
                var menuItems = this.menuItemRepository.GetAll().ProjectTo<GetMenuItemDto>(mapper.ConfigurationProvider);
                return ServiceResponse<List<GetMenuItemDto>>.Succeeded(BuildMenuTree(await menuItems.ToListAsync(), null), "Menu items retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<GetMenuItemDto>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<GetDataTableDto>> GetDataTable(string name)
        {
            try
            {
                var datatable = await dataTableRepository.GetAll().Where(p => p.Name == name).OrderBy(p => p).ProjectTo<GetDataTableDto>(mapper.ConfigurationProvider).SingleOrDefaultAsync();
                return ServiceResponse<GetDataTableDto>.Succeeded(datatable, "DataTable retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetDataTableDto>.Failed(null, ex.Message);
            }
        }

        private List<GetMenuItemDto> BuildMenuTree(
            List<GetMenuItemDto> menuItems,
            Guid? parentId)
        {
            return menuItems
                .Where(x => x.ParentId == parentId)
                .OrderBy(x => x.Order)
                .Select(x =>
                {
                    var children = BuildMenuTree(menuItems, x.Id);

                    return new GetMenuItemDto
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Icon = x.Icon,
                        Link = x.Link,
                        Url = x.Url,
                        Target = x.Target,
                        Data = x.Data,
                        Home = x.Home,
                        Group = x.Group,
                        Expanded = x.Expanded,
                        Hidden = x.Hidden,
                        children = children.Count == 0 ? null : children
                    };
                })
                .ToList();
        }
    }
}
