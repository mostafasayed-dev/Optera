using HotChocolate.Authorization;
using Optera.GraphQL.Models;
using Optera.GraphQL.Pagination;
using Optera.GraphQL.Response;
using Optera.GraphQL.Services.Interfaces;

namespace Optera.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    [Authorize]
    public class UserQuery
    {
        public async Task<ServiceResponse<User>?> GetUserById(
            [Service] IUserService userService, 
            string id) 
        {
            return await userService.GetUserById(id);
        }

        public async Task<ServiceResponse<IEnumerable<User>>?> GetUsers(
            [Service] IUserService userService,
            UserParams? userParams)
        {
            return await userService.GetUsers(userParams);
        }
    }
}
