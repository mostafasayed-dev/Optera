using Optera.Configuration.Models;
using Optera.Configuration.Repositories.Interfaces;
using Optera.Shared.Core.Identity;
using Optera.Shared.Core.Repositories;

namespace Optera.Configuration.Repositories
{
    public class MenuItemRepository : BaseRepository<MenuItem, AppDbContext>, IMenuItemRepository
    {
        public MenuItemRepository(AppDbContext appDbContext, ICurrentUserContext currentUserContext) : base(appDbContext, currentUserContext)
        {
        }
    }
}
