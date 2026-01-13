using Optera.DTOs.CategoryItem;
using Optera.Utils.Pagination;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.Interfaces
{
    public interface ICategoryItemRepository
    {
        public Task<ServiceResponse<PagedList<GetCategoryItemDto>>> GetCategoryItems(long id, UserParams? userParams);
        public Task<ServiceResponse<GetCategoryItemDto>> CreateCategoryItem(CreateCategoryItemDto createCategoryItemDto);
        public Task<ServiceResponse<GetCategoryItemDto>> UpdateCategoryItem(UpdateCategoryItemDto updateCategoryItemDto);
        public Task<ServiceResponse<PagedList<GetCategoryItemDto>>> Search(string value, UserParams? userParams);
        public Task<ServiceResponse<ICollection<GetCategoryItemListDto>>> GetCategoryItemsList(long categoryId);
    }
}
