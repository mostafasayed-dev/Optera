using Optera.Configuration.Models;
using Optera.Configuration.Repositories.Interfaces;
using Optera.Shared.Core.Identity;
using Optera.Shared.Core.Repositories;

namespace Optera.Configuration.Repositories
{
    public class ComponentFormRepository : BaseRepository<ComponentForm, AppDbContext>, IComponentFormRepository
    {
        public ComponentFormRepository(AppDbContext appDbContext, ICurrentUserContext currentUserContext) : base(appDbContext, currentUserContext)
        {
        }
    }
}
