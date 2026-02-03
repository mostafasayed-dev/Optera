using Optera.Query.Models;
using Optera.Query.Repositories.Interfaces;
using Optera.Shared.Core.Identity;
using Optera.Shared.Core.Repositories;

namespace Optera.Query.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, AppDbContext>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext appDbContext, ICurrentUserContext currentUserContext) 
            : base(appDbContext, currentUserContext)
        {
        }
    }
}
