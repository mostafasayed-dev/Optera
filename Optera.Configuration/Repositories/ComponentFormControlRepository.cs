using Optera.Configuration.Models;
using Optera.Configuration.Repositories.Interfaces;
using Optera.Shared.Core.Identity;
using Optera.Shared.Core.Repositories;

namespace Optera.Configuration.Repositories
{
    public class ComponentFormControlRepository : BaseRepository<ComponentFormControl, AppDbContext>, IComponentFormControlRepository
    {
        public ComponentFormControlRepository(AppDbContext appDbContext, ICurrentUserContext currentUserContext) : base(appDbContext, currentUserContext)
        {
        }
    }
}
