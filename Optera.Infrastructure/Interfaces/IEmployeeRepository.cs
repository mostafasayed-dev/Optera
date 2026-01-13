using Optera.DTOs.Employee;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<ServiceResponse<GetEmployeeDto>> CreateEmployee(CreateEmployeeDto createEmployeeDto);
    }
}
