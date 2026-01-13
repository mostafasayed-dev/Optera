using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Optera.DataAccess;
using Optera.DTOs.Core;
using Optera.DTOs.Country;
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
    public class DataTableColumnRepository : BaseRepository<DataTableColumn>, IDataTableColumnRepository
    {
        private readonly IMapper mapper;
        public DataTableColumnRepository(DBContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(context, httpContextAccessor)
        {
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<PagedList<GetDataTableColumnDto>>> GetDataTableColumns(UserParams? userParams, string name)
        {
            try
            {
                var datatableColumns = Get().Where(p => p.DataTable.Name == name).OrderBy(p => p.Order).ProjectTo<GetDataTableColumnDto>(mapper.ConfigurationProvider);
                var result = await PagedList<GetDataTableColumnDto>.CreatePageAsync(datatableColumns, userParams);
                return ServiceResponse<PagedList<GetDataTableColumnDto>>.Succeeded(result, "DataTable Columns retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<PagedList<GetDataTableColumnDto>>.Failed(null, ex.Message);
            }
        }
    }
}
