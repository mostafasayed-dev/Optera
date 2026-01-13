using Optera.Query.Models;
using Optera.Query.Repositories.Base;
using Optera.Query.Repositories.Interfaces;

namespace Optera.Query.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
