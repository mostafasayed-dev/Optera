using Microsoft.AspNetCore.Mvc;
using Optera.Controllers.Base;
using Optera.DTOs.Employee;
using Optera.DTOs.User;
using Optera.Infrastructure.Interfaces;
using Optera.Utils.Response;

namespace Optera.Controllers
{
    public class EmployeeController : BaseApiController
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IAuthRepository userRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, IAuthRepository userRepository)
        {
            this.employeeRepository = employeeRepository;
            this.userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetEmployeeDto>>> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            var result = await employeeRepository.CreateEmployee(createEmployeeDto);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
