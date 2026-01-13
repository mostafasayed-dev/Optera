using Microsoft.AspNetCore.Mvc;
using Optera.HRM.Controllers.Base;
using Optera.HRM.DTOs.Employee;
using Optera.HRM.Services.Interfaces;
using Optera.Shared.Response;

namespace Optera.HRM.Controllers
{
    public class EmployeeController : BaseApiController
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<string>>> CreateEmployee(CreateEmployee createEmployee)
        {
            var result = await employeeService.CreateEmployee(createEmployee);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
