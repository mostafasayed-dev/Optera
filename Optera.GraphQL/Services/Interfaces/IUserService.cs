using Optera.GraphQL.Models;
using Optera.GraphQL.Pagination;
using Optera.GraphQL.Response;

namespace Optera.GraphQL.Services.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<User>?> GetUserById(string id);
        Task<ServiceResponse<IEnumerable<User>>?> GetUsers(UserParams? userParams);
    }
}
