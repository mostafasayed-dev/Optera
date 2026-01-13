using Optera.Query.Models;
using Optera.Query.Repositories.Base;
using Optera.Query.Repositories.Interfaces;

namespace Optera.Query.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
