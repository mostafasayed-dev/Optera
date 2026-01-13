using Optera.GraphQL.Extensions;
using Optera.GraphQL.Models;
using Optera.GraphQL.Pagination;
using Optera.GraphQL.Response;
using Optera.GraphQL.Services.Interfaces;
using System.Net.Http.Headers;

namespace Optera.GraphQL.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient http;

        public UserService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<ServiceResponse<User>?> GetUserById(string id)
        {
            return await http.GetServiceResponseAsync<User>($"auth/user/{id}");
        }

        public async Task<ServiceResponse<IEnumerable<User>>?> GetUsers(UserParams? userParams)
        {
            return await http.GetServiceResponseAsync<IEnumerable<User>>($"auth/users", userParams);
        }
    }
}
