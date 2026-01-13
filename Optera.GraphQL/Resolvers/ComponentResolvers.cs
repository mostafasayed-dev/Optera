using Optera.GraphQL.DataLoaders;
using Optera.GraphQL.Models;
using Optera.GraphQL.Services;
using Optera.GraphQL.Services.Interfaces;

namespace Optera.GraphQL.Resolvers
{
    [ExtendObjectType(typeof(Component))]
    public class ComponentResolvers
    {

        public ComponentResolvers()
        {

        }

        public async Task<User> GetCreatorAsync([Parent] Component component, UserByIdDataLoader userById)
        {
            //var user = await this.userService.GetUserById(component.Creator.ToString());
            //return user?.Result?.Username ?? "Unknown";
            var user = await userById.LoadAsync(component.Creator.ToString());
            return user;
        }

        public async Task<string> GetUpdatorAsync([Parent] Component component, UserByIdDataLoader userById)
        {
            //var user = await this.userService.GetUserById(component.Updator.ToString());
            //return user?.Result?.Username ?? "Unknown";
            var user = await userById.LoadAsync(component.Updator.ToString());
            return user?.Username ?? "Unknown";
        }
    }
}
