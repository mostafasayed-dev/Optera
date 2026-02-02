using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optera.Shared.Core.Identity
{
    public interface ICurrentUserContext
    {
        /// <summary>
        /// The current user's unique ID (from JWT "sub").
        /// Returns null if not available (e.g., background tasks).
        /// </summary>
        string? UserId { get; }

        /// <summary>
        /// The current user's username (from JWT "unique_name").
        /// Returns null if not available (e.g., background tasks).
        /// </summary>
        string? UserName { get; }
    }
}
