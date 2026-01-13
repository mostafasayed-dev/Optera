using Optera.Query.Models;

namespace Optera.Query.Services.Interfaces
{
    public interface IUserService
    {
        public Task<bool> CreateUser(User user);
    }
}
