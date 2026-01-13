using Optera.DTOs.Category;
using Optera.Utils.Pagination;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<ServiceResponse<PagedList<GetCategoryDto>>> GetCategories(UserParams? userParams);
        public Task<ServiceResponse<PagedList<GetCategoryDto>>> Search(string value, UserParams? userParams);
    }
}
