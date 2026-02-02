using Optera.HRM.Models;
using Optera.HRM.Reopositories.Interfaces;
using Optera.Shared.Core.Identity;
using Optera.Shared.Core.Repositories;

namespace Optera.HRM.Reopositories
{
    public class EmployeeRepository : BaseRepository<Employee, AppDbContext>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext appDbContext, ICurrentUserContext currentUserContext) : base(appDbContext, currentUserContext)
        {
        }
    }
}
