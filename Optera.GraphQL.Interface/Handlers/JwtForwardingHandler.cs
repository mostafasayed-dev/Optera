using System.Net.Http.Headers;

namespace Optera.GraphQL.Interface.Handlers
{
    public class JwtForwardingHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtForwardingHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
                return base.SendAsync(request, cancellationToken);

            var token = httpContext.Request.Headers["Authorization"].ToString();

            if (!string.IsNullOrEmpty(token))
            {
                // Normalize in case "bearer" is lowercased or missing
                if (!token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                    token = $"Bearer {token}";

                request.Headers.Authorization = AuthenticationHeaderValue.Parse(token);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}