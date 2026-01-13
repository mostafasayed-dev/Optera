using Optera.Utils.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Utils.Response
{
    public class ServiceResponse<T>
    {
        private ServiceResponse(T result, bool success, string title = null, string message = "", ServiceStatus status = ServiceStatus.None)
        {
            Success = success;
            Result = result;
            Message = message;
            Status = status;
            Title = title;
        }

        #region Response
        public bool Success { get; }
        public ServiceStatus Status { get; }
        public T Result { get; }
        public string Title { get; set; }
        public string Message { get; }
        #endregion

        public static ServiceResponse<T> Succeeded(T data, string message = "") => new ServiceResponse<T>(data, true, "Succeeded", message, ServiceStatus.Succeeded);
        //public static ServiceResponse<T> Empty(T data, string message = "") => new ServiceResponse<T>(data, true, message, ServiceStatus.Empty);
        public static ServiceResponse<T> Failed(T data, string message = "") => new ServiceResponse<T>(data, false, "Error", message, ServiceStatus.Failed);
        public static ServiceResponse<T> NotFound(T data, string message = "") => new ServiceResponse<T>(data, false, "Error", message, ServiceStatus.NotFound);
        public static ServiceResponse<T> AlreadyExists(T data, string message = "") => new ServiceResponse<T>(data, false, "Warning", message, ServiceStatus.AlreadyExists);
        public static ServiceResponse<T> UniqueConstraintError(T data, string message = "") => new ServiceResponse<T>(data, false, "Error", message, ServiceStatus.UniqueConstraint);
        public static ServiceResponse<T> ConstraintCheckError(T data, string message = "") => new ServiceResponse<T>(data, false, "Error", message, ServiceStatus.UniqueConstraint);
        public static ServiceResponse<T> DublicateKeyError(T data, string message = "") => new ServiceResponse<T>(data, false, "Error", message, ServiceStatus.UniqueConstraint);
        public static ServiceResponse<T> EmailNotConfirmed(T data, string message = "") => new ServiceResponse<T>(data, false, "Error", message, ServiceStatus.EmailNotConfirmed);
        public static ServiceResponse<T> InvalidUsernameOrPassword(T data, string message = "") => new ServiceResponse<T>(data, false, "Error", message, ServiceStatus.InvalidUsernameOrPassword);
        public static ServiceResponse<T> UserLocked(T data, string message = "") => new ServiceResponse<T>(data, false, "Error", message, ServiceStatus.UserLocked);
        //public static ServiceResponse<T> Invalid(T data, string message = "") => new ServiceResponse<T>(data, false, message, ServiceStatus.Invalid);
        //public static ServiceResponse<T> DatabaseOperationFailed(T data, string message = "", ServiceStatus status = ServiceStatus.DatabaseOperationFailed) => new ServiceResponse<T>(data, false, message,  status);

        //public static ServiceResponse<T> Failed(Exception exception)
        //{
        //    if (exception.GetBaseException().GetType() == typeof(SqlException))
        //    {
        //        Int32 ErrorCode = ((SqlException)exception.InnerException).Number;
        //        string message = "Database error occured while processing data!";

        //        switch (ErrorCode)
        //        {
        //            case 2627:  // Unique constraint error
        //                break;
        //            case 547:   // Constraint check violation
        //                break;
        //            case 2601:  // Duplicated key row error
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}
    }
}
