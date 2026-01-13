using Optera.GraphQL.Interface.Enums;
using Optera.GraphQL.Interface.Pagination;
using Optera.GraphQL.Interface.Response;

namespace Optera.GraphQL.Interface.Services.Interfaces
{
    public interface IGraphQLClientService
    {
        public Task<ServiceResponse<T>?> ExecuteQueryAsync<T>(Queries query, object? variables = null, UserParams? userParams = null, CancellationToken cancellationToken = default);
    }
}
