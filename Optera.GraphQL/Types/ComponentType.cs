using Optera.GraphQL.Models;
using Optera.GraphQL.Resolvers;
using Optera.GraphQL.Services.Interfaces;

namespace Optera.GraphQL.Types
{
    public class ComponentType : ObjectType<Component>
    {
        protected override void Configure(IObjectTypeDescriptor<Component> descriptor)
        {
            descriptor.Field(c => c.Name).Type<StringType>();
            descriptor.Field(c => c.Title).Type<StringType>();

            descriptor.Field(c => c.Creator);
            descriptor.Field(c => c.Updator);

            descriptor
            .Field("creatorObject")
            .ResolveWith<ComponentResolvers>(r => r.GetCreatorAsync(default!, default!));

            descriptor
            .Field("updatorName")
            .Type<StringType>()
            .ResolveWith<ComponentResolvers>(r => r.GetUpdatorAsync(default!, default!));
        }
    }
}
