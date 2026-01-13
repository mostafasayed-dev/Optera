using Optera.Configuration.Models;
using Optera.Configuration.Repositories.Base;
using Optera.Configuration.Repositories.Interfaces;

namespace Optera.Configuration.Repositories
{
    public class MenuItemRepository : BaseRepository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
