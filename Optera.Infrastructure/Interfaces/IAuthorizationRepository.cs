using Optera.DTOs.Core;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.Interfaces
{
    public interface IAuthorizationRepository
    {
        public Task<ServiceResponse<List<GetAuthorizationDto>>> GetAuthorizations();
    }
}
