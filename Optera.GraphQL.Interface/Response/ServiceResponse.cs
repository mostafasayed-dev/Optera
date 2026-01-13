namespace Optera.GraphQL.Interface.Response
{
    public class ServiceResponse<T>
    {
        private ServiceResponse(T result, bool success, string title = null, string message = "", ResponseStatus status = ResponseStatus.NONE)
        {
            Success = success;
            Result = result;
            Message = message;
            Status = status;
            Title = title;
        }

        public ServiceResponse() { }

        public bool Success { get; set; }
        public ResponseStatus Status { get; set; }
        public T Result { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }


        public static ServiceResponse<T> Failed(T data, string message = "") => new ServiceResponse<T>(data, false, "Error", message, ResponseStatus.FAILED);
    }
}
