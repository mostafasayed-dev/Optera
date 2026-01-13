using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
    public class DataTableRepository : BaseRepository<DataTable>, IDataTableRepository
    {
        private readonly IMapper mapper;
        public DataTableRepository(DBContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(context, httpContextAccessor)
        {
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<GetDataTableDto>> GetDataTable(UserParams? userParams, string name)
        {
            try
            {
                var datatable = await Get().Where(p => p.Name == name).OrderBy(p => p).ProjectTo<GetDataTableDto>(mapper.ConfigurationProvider).SingleOrDefaultAsync();
                return ServiceResponse<GetDataTableDto>.Succeeded(datatable, "DataTable retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetDataTableDto>.Failed(null, ex.Message);
            }
        }
    }
}
