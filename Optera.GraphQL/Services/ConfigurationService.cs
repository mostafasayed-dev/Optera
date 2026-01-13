using Optera.GraphQL.Extensions;
using Optera.GraphQL.Models;
using Optera.GraphQL.Pagination;
using Optera.GraphQL.Response;
using Optera.GraphQL.Services.Interfaces;
using static System.Net.WebRequestMethods;

namespace Optera.GraphQL.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly HttpClient httpClient;

        public ConfigurationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ServiceResponse<IEnumerable<Component>>?> GetComponents(UserParams? userParams)
        {
            return await httpClient.GetServiceResponseAsync<IEnumerable<Component>>($"configuration/components", userParams);
        }
    }
}
