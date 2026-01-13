using Optera.GraphQL.Models;
using Optera.GraphQL.Response;

namespace Optera.GraphQL.Types
{
    public class ServiceResponseType<T> : ObjectType<ServiceResponse<T>>
    {
        protected override void Configure(IObjectTypeDescriptor<ServiceResponse<T>> descriptor)
        {
            descriptor.Field(t => t.Success).Type<NonNullType<BooleanType>>();
            descriptor.Field(t => t.Status).Type<EnumType<ResponseStatus>>();
            descriptor.Field(t => t.Result).Type<ObjectType<T>>();
            descriptor.Field(t => t.Title).Type<StringType>();
            descriptor.Field(t => t.Message).Type<StringType>();
        }
    }
}
