using HotChocolate.Authorization;
using Optera.GraphQL.Models;
using Optera.GraphQL.Pagination;
using Optera.GraphQL.Response;
using Optera.GraphQL.Services.Interfaces;

namespace Optera.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    [Authorize]
    public class ConfigurationQuery
    {
        public async Task<ServiceResponse<IEnumerable<Component>>?> GetComponents(
            [Service] IConfigurationService configurationService,
            UserParams? userParams)
        {
            return await configurationService.GetComponents(userParams);
        }
    }
}
