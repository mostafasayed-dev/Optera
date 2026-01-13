using Optera.HRM.DTOs.Employee;
using Optera.Shared.Response;

namespace Optera.HRM.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<ServiceResponse<GetEmployee>> CreateEmployee(CreateEmployee createEmployee);
    }
}
