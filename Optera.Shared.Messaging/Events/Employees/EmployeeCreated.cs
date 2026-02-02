using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optera.Shared.Messaging.Events.Employees
{
    public record EmployeeCreated(
        long Id,
        string FirstName,
        string MiddleName,
        string LastName,
        char Gender,
        DateTime DateOfBirth
    ) : IEvent
    {
        public string Username { get; set; } = default!;
        public DateTime OccurredAt { get; init; } = DateTime.UtcNow;
    }
}
