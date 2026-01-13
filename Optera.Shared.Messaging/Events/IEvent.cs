using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optera.Shared.Messaging.Events
{
    public interface IEvent
    {
        string Username { get; }
        DateTime OccurredAt { get; }

    }
}
