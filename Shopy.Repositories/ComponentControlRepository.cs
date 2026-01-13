using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Optera.DataAccess;
using Optera.DTOs.Core;
using Optera.Infrastructure;
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
    public class ComponentControlRepository : BaseRepository<ComponentFormControl>, IComponentControlRepository
    {
        private readonly IMapper mapper;

        public ComponentControlRepository(DBContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(context, httpContextAccessor)
        {
            this.mapper = mapper;
        }

        //public async Task<ServiceResponse<PagedList<GetComponentControlDto>>> GetComponentControls(UserParams? userParams, string name)
        //{
        //    try
        //    {
        //        var componentControls = Get().Where(p => p.Component.Name == name).ProjectTo<GetComponentControlDto>(mapper.ConfigurationProvider);
        //        var result = await PagedList<GetComponentControlDto>.CreatePageAsync(componentControls, userParams.PageNumber, userParams.PageSize);
        //        return ServiceResponse<PagedList<GetComponentControlDto>>.Succeeded(result, "Component controls retrieved successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return ServiceResponse<PagedList<GetComponentControlDto>>.Failed(null, ex.Message);
        //    }
        //}
    }
}
