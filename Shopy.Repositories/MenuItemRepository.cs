using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Optera.DataAccess;
using Optera.DTOs.City;
using Optera.DTOs.Core;
using Optera.Infrastructure.Interfaces;
using Optera.Models;
using Optera.Repositories.Base;
using Optera.Utils.Pagination;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Repositories
{
    public class MenuItemRepository : BaseRepository<MenuItem>, IMenuItemRepository
    {
        private readonly IMapper mapper;

        public MenuItemRepository(DBContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(context, httpContextAccessor)
        {
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetMenuItemDto>>> GetMenuItems()
        {
            try
            {
                var menuItems = Get().ProjectTo<GetMenuItemDto>(mapper.ConfigurationProvider);
                return ServiceResponse<List<GetMenuItemDto>>.Succeeded(BuildMenuTree(await menuItems.ToListAsync(), null), "Menu items retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<GetMenuItemDto>>.Failed(null, ex.Message);
            }
        }

        private List<GetMenuItemDto> BuildMenuTree(List<GetMenuItemDto> menuItems, long? parentId)
        {
            return menuItems
                .Where(x => x.ParentId == parentId)
                .OrderBy(x => x.Order)
                .Select(x => new GetMenuItemDto 
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
                    children = BuildMenuTree(menuItems, x.Id).Count == 0 ? null : BuildMenuTree(menuItems, x.Id)
                }).ToList();
        }

    }
}
