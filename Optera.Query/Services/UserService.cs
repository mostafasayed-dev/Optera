using AutoMapper;
using Optera.Query.Models;
using Optera.Query.Repositories.Interfaces;
using Optera.Query.Services.Interfaces;

namespace Optera.Query.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<bool> CreateUser(User user)
        {
            try
            {
                await userRepository.AddAsync(user);
                return await userRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
