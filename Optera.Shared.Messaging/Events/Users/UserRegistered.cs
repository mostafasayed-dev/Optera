using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optera.Shared.Messaging.Events.Users
{
    public record UserRegistered(
        long Id,
        string UserName,
        string NormalizedUserName,
        string Email,
        string NormalizedEmail,
        bool EmailConfirmed,
        string PhoneNumber,
        bool PhoneNumberConfirmed
    ) : IEvent
    {
        public string Username { get; set; } = default!;
        public DateTime OccurredAt { get; init; } = DateTime.UtcNow;
    }
}
