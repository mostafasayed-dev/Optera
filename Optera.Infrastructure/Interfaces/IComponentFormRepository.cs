using Optera.DTOs.Core;
using Optera.Utils.Pagination;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.Interfaces
{
    public interface IComponentFormRepository
    {
        public Task<ServiceResponse<PagedList<GetComponentFormDto>>> GetComponentForms(UserParams? userParams, string name);
    }
}
