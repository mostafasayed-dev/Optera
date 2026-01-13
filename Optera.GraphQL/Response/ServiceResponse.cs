using System.Text.Json.Serialization;

namespace Optera.GraphQL.Response
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public ResponseStatus Status { get; set; }
        public T Result { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
