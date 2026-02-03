using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optera.Shared.Messaging.Events.Users
{
    public record UserLoggedInEvent(
        long Id,
        string UserName,
        string Email,
        DateTime OccurredAt = default!
    );
}
