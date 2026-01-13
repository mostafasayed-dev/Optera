using Microsoft.AspNetCore.Mvc;
using Optera.Controllers.Base;
using Optera.DTOs.Customer;
using Optera.DTOs.Employee;
using Optera.Infrastructure.Interfaces;
using Optera.Repositories;
using Optera.Utils.Response;

namespace Optera.Controllers
{
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCustomerDto>>> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            var result = await customerRepository.CreateCustomer(createCustomerDto);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
