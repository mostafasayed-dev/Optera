using Optera.Query.Models;

namespace Optera.Query.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<bool> CreateEmployee(Employee employee);
    }
}
