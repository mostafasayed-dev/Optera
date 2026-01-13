using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optera.Shared.Response
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

        #region Response
        public bool Success { get; }
        public ResponseStatus Status { get; }
        public T Result { get; }
        public string Title { get; set; }
        public string Message { get; }
        #endregion

        public static ServiceResponse<T> Succeeded(T data, string message = "") => new ServiceResponse<T>(data, true, "Succeeded", message, ResponseStatus.SUCCEEDED);
        public static ServiceResponse<T> Failed(T data, string message = "") => new ServiceResponse<T>(data, false, "Error", message, ResponseStatus.FAILED);
        public static ServiceResponse<T> NotFound(T data, string message = "") => new ServiceResponse<T>(data, false, "Error", message, ResponseStatus.NOT_FOUND);
        public static ServiceResponse<T> Warning(T data, string message = "") => new ServiceResponse<T>(data, false, "Error", message, ResponseStatus.INVALID);
        public static ServiceResponse<T> NotAuthorized(T data, string message = "") => new ServiceResponse<T>(data, false, "Error", message, ResponseStatus.NOT_AUTHORIZED);
    }
}
