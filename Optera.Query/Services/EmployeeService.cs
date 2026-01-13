using AutoMapper;
using Optera.Query.Models;
using Optera.Query.Repositories;
using Optera.Query.Repositories.Interfaces;
using Optera.Query.Services.Interfaces;

namespace Optera.Query.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public EmployeeService(IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        public async Task<bool> CreateEmployee(Employee employee)
        {
            try
            {
                await this.employeeRepository.AddAsync(employee);
                return await this.employeeRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
