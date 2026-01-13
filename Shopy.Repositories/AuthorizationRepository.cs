using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Optera.DataAccess;
using Optera.DTOs.Core;
using Optera.Infrastructure.Interfaces;
using Optera.Models;
using Optera.Repositories.Base;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Repositories
{
    public class AuthorizationRepository : BaseRepository<Authorization>, IAuthorizationRepository
    {
        private readonly IMapper mapper;

        public AuthorizationRepository(DBContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(context, httpContextAccessor)
        {
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetAuthorizationDto>>> GetAuthorizations()
        {
            try
            {
                var authorizations = Get().ProjectTo<GetAuthorizationDto>(mapper.ConfigurationProvider);
                return ServiceResponse<List<GetAuthorizationDto>>.Succeeded(BuildAuthorizationsTree(await authorizations.ToListAsync(), null), "Authorizations retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<GetAuthorizationDto>>.Failed(null, ex.Message);
            }
        }

        private List<GetAuthorizationDto> BuildAuthorizationsTree(List<GetAuthorizationDto> authorizations, long? parentId)
        {
            return authorizations
                .Where(x => x.ParentId == parentId && !x.Code.StartsWith("AUTH_3"))
                .OrderBy(x => x.Order)
                .Select(x => new GetAuthorizationDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    ParentId = x.ParentId,
                    Order = x.Order,
                    Selected = x.Selected,
                    Children = BuildAuthorizationsTree(authorizations, x.Id)
                }).ToList();
        }
    }
}
