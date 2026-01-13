using System.Net.Http.Headers;

namespace Optera.GraphQL.Handlers
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
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();

            if (!string.IsNullOrEmpty(token))
            {
                // Set the Authorization header dynamically
                request.Headers.Authorization = AuthenticationHeaderValue.Parse(token);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
