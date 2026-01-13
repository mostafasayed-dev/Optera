using Microsoft.EntityFrameworkCore;
using Optera.Configuration.Models;
using Optera.Configuration.Repositories.Base;
using Optera.Configuration.Repositories.Interfaces;
using System.Collections;

namespace Optera.Configuration.Repositories
{
    public class ComponentFormRepository : BaseRepository<ComponentForm>, IComponentFormRepository
    {
        public ComponentFormRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
