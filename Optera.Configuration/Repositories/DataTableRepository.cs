using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Optera.Configuration.DTOs;
using Optera.Configuration.Models;
using Optera.Configuration.Repositories.Base;
using Optera.Configuration.Repositories.Interfaces;
using Optera.Shared.Pagination.Pagination;
using Optera.Shared.Response;

namespace Optera.Configuration.Repositories
{
    public class DataTableRepository : BaseRepository<DataTable>, IDataTableRepository
    {
        public DataTableRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
