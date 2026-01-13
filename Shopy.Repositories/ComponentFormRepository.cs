using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Optera.DataAccess;
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
    public class ComponentFormRepository : BaseRepository<ComponentForm>, IComponentFormRepository
    {
        private readonly IMapper mapper;

        public ComponentFormRepository(DBContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(context, httpContextAccessor)
        {
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<PagedList<GetComponentFormDto>>> GetComponentForms(UserParams? userParams, string name)
        {
            try
            {
                var componentForms = Get().Where(p => p.Component.Name == name).ProjectTo<GetComponentFormDto>(mapper.ConfigurationProvider);
                var result = await PagedList<GetComponentFormDto>.CreatePageAsync(componentForms, userParams);
                return ServiceResponse<PagedList<GetComponentFormDto>>.Succeeded(result, "Component forms retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<PagedList<GetComponentFormDto>>.Failed(null, ex.Message);
            }
        }
    }
}
