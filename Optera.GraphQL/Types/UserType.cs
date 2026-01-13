using Optera.GraphQL.Models;

namespace Optera.GraphQL.Types
{
    public class UserType : ObjectType<User>
    {

        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(t => t.Id).Type<IdType>(); // nullable
            descriptor.Field(t => t.Username).Type<StringType>(); // nullable
            descriptor.Field(t => t.Email).Type<StringType>(); // nullable
            descriptor.Field(t => t.EmailConfirmed).Type<BooleanType>(); // nullable
            descriptor.Field(t => t.Locked).Type<IntType>(); // nullable
        }
    }
}
