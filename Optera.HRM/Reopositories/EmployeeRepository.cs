using Optera.HRM.Models;
using Optera.HRM.Reopositories.Base;
using Optera.HRM.Reopositories.Interfaces;

namespace Optera.HRM.Reopositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
