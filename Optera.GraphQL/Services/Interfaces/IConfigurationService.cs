using Optera.GraphQL.Models;
using Optera.GraphQL.Pagination;
using Optera.GraphQL.Response;

namespace Optera.GraphQL.Services.Interfaces
{
    public interface IConfigurationService
    {
        public Task<ServiceResponse<IEnumerable<Component>>?> GetComponents(UserParams? userParams);
    }
}
