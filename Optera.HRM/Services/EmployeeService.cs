using AutoMapper;
using MassTransit;
using Optera.HRM.DTOs.Employee;
using Optera.HRM.Models;
using Optera.HRM.Reopositories.Interfaces;
using Optera.HRM.Services.Interfaces;
using Optera.Shared.Core.Identity;
using Optera.Shared.Core.Repositories;
using Optera.Shared.Identity;
using Optera.Shared.Messaging.Events.Employees;
using Optera.Shared.Response;

namespace Optera.HRM.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ICurrentUserContext currentUserContext;

        public EmployeeService(IUnitOfWork unitOfWork,
            IEmployeeRepository employeeRepository,
            IMapper mapper,
            IPublishEndpoint publishEndpoint,
            ICurrentUserContext currentUserContext)
        {
            this.unitOfWork = unitOfWork;
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
            this.publishEndpoint = publishEndpoint;
            this.currentUserContext = currentUserContext;
        }

        public async Task<ServiceResponse<GetEmployee>> CreateEmployee(CreateEmployee createEmployee, CancellationToken ct = default)
        {
            try
            {
                var employee = mapper.Map<Employee>(createEmployee);
                await employeeRepository.AddAsync(employee);

                var @event = new EmployeeCreated(
                        employee.Id,
                        employee.FirstName,
                        employee.MiddleName,
                        employee.LastName,
                        employee.Gender,
                        employee.DateOfBirth
                    )
                {
                    Username = currentUserContext.UserName
                };

                await publishEndpoint.Publish(@event);

                var result = await unitOfWork.SaveChangesAsync(ct);
                if (result <= 0)
                    return ServiceResponse<GetEmployee>.Failed(null, "Employee creation failed!");

                return ServiceResponse<GetEmployee>.Succeeded(mapper.Map<GetEmployee>(employee), "Employee created successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetEmployee>.Failed(null, ex.Message);
            }
        }
    }
}
