using Optera.GraphQL.Models;
using Optera.GraphQL.Services;
using Optera.GraphQL.Services.Interfaces;

namespace Optera.GraphQL.DataLoaders
{
    public class UserByIdDataLoader : BatchDataLoader<string, User>
    {
        private readonly IUserService userService;
        public UserByIdDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, 
            IUserService userService) : base(batchScheduler, options)
        {
            this.userService = userService;
        }

        protected override async Task<IReadOnlyDictionary<string, User>> LoadBatchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
        {
            var result = new Dictionary<string, User>();

            foreach (var id in keys)
            {
                var response = await userService.GetUserById(id);
                if (response?.Result != null)
                {
                    result[id] = response.Result;
                }
            }

            return result;
        }
    }
}
