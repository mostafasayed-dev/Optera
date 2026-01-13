using Optera.DTOs.Core;
using Optera.Utils.Pagination;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.Interfaces
{
    public interface IMenuItemRepository
    {
        public Task<ServiceResponse<List<GetMenuItemDto>>> GetMenuItems();
    }
}
