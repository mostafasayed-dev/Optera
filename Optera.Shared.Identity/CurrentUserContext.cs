using Microsoft.AspNetCore.Http;
using Optera.Shared.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Optera.Shared.Identity
{
    public class CurrentUserContext : ICurrentUserContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CurrentUserContext(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string? UserId
        {
            get
            {
                var httpContext = httpContextAccessor.HttpContext;
                if (httpContext == null) return null;

                var claim = httpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                return claim?.Value;
            }
        }

        public string? UserName
        {
            get
            {
                var httpContext = httpContextAccessor.HttpContext;
                if (httpContext == null) return null;

                var claim = httpContext.User.FindFirst(ClaimTypes.Name);
                return claim?.Value;
            }
        }
    }
}
