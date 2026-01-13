using Microsoft.EntityFrameworkCore;
using Optera.Configuration.Models;
using Optera.Configuration.Repositories.Base;
using Optera.Configuration.Repositories.Interfaces;

namespace Optera.Configuration.Repositories
{
    public class ComponentRepository : BaseRepository<Component>, IComponentRepository
    {
        public ComponentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
