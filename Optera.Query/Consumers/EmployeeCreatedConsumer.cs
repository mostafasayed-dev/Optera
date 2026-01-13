using MassTransit;
using Optera.Query.Models;
using Optera.Query.Services.Interfaces;
using Optera.Shared.Messaging.Events.Employees;

namespace Optera.Query.Consumers
{
    public class EmployeeCreatedConsumer : IConsumer<EmployeeCreated>
    {
        private readonly IEmployeeService employeeService;

        public EmployeeCreatedConsumer(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public async Task Consume(ConsumeContext<EmployeeCreated> context)
        {
            var @event = context.Message;

            var employee = new Employee
            {
                Id = @event.Id,
                FirstName = @event.FirstName,
                MiddleName = @event.MiddleName,
                LastName = @event.LastName,
                Gender = @event.Gender,
                DateOfBirth = @event.DateOfBirth,
                Creator = @event.Username,
                Updater = @event.Username,
            };

            await this.employeeService.CreateEmployee(employee);
        }
    }
}
