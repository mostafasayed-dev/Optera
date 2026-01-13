using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Utils.Models
{
    public enum ServiceStatus
    {
        None = 0,
        Succeeded = 100,
        Failed = -100,
        NotFound = -101,
        AlreadyExists = -102,
        //Invalid = -102,
        //Empty = -200,
        //DatabaseOperationFailed = -300,
        UniqueConstraint = -301,
        ConstraintCheck = -302,
        DublicateKey = -303,

        EmailNotConfirmed = -400,
        InvalidUsernameOrPassword = -401,
        UserLocked = -402,
    }
}
