using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optera.Shared.Messaging.Events.Miscellaneous
{
    public record CountryUpdated(
        Guid Id,
        string Name,
        string? Name_OtherLanguage,
        string? ISOCode
    ) : IEvent
    {
        public string Username { get; set; } = default!;
        public DateTime OccurredAt { get; init; } = DateTime.UtcNow;
    }
}
