using Optera.Configuration.Models;
using Optera.Configuration.Repositories.Base;
using Optera.Configuration.Repositories.Interfaces;

namespace Optera.Configuration.Repositories
{
    public class ComponentFormControlRepository : BaseRepository<ComponentFormControl>, IComponentFormControlRepository
    {
        public ComponentFormControlRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
