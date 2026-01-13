using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Optera.DataAccess;
using Optera.DTOs.CategoryItem;
using Optera.DTOs.City;
using Optera.DTOs.Country;
using Optera.DTOs.Region;
using Optera.Infrastructure.Interfaces;
using Optera.Models;
using Optera.Repositories.Base;
using Optera.Utils.Models;
using Optera.Utils.Pagination;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Repositories
{
    public class CategoryItemRepository : BaseRepository<CategoryItem>, ICategoryItemRepository
    {
        private readonly IMapper mapper;

        public CategoryItemRepository(DBContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(context, httpContextAccessor)
        {
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<PagedList<GetCategoryItemDto>>> GetCategoryItems(long id, UserParams? userParams)
        {
            try
            {
                var categoryItems = Get().Where(p => p.CategoryId == id).ProjectTo<GetCategoryItemDto>(mapper.ConfigurationProvider);
                var result = await PagedList<GetCategoryItemDto>.CreatePageAsync(categoryItems, userParams);
                return ServiceResponse<PagedList<GetCategoryItemDto>>.Succeeded(result, "Category items retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<PagedList<GetCategoryItemDto>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<ICollection<GetCategoryItemListDto>>> GetCategoryItemsList(long categoryId)
        {
            try
            {
                var categoryItems = await GetByStatusAsync(Status.Active);
                if (categoryItems == null)
                    throw new Exception("Can't retrieve Category Items List!");
                categoryItems = categoryItems.Where(p => p.CategoryId == categoryId).OrderBy(p => p.Name).ToList();
                return ServiceResponse<ICollection<GetCategoryItemListDto>>.Succeeded(mapper.Map<ICollection<GetCategoryItemListDto>>(categoryItems), "Countries List retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<ICollection<GetCategoryItemListDto>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<GetCategoryItemDto>> CreateCategoryItem(CreateCategoryItemDto createCategoryItemDto)
        {
            try
            {
                var categoryItem = mapper.Map<CategoryItem>(createCategoryItemDto);
                Add(categoryItem);
                var result = await SaveChangesAsync();
                if (result.Success)
                {
                    return ServiceResponse<GetCategoryItemDto>.Succeeded(mapper.Map<GetCategoryItemDto>(categoryItem), "Category item created successfully.");
                }

                return ServiceResponse<GetCategoryItemDto>.Failed(null, "Category item creation failed!");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetCategoryItemDto>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<GetCategoryItemDto>> UpdateCategoryItem(UpdateCategoryItemDto updateCategoryItemDto)
        {
            try
            {
                var categoryItem = await GetByIdAsync(updateCategoryItemDto.Id);
                if (categoryItem != null)
                {
                    categoryItem.Name = updateCategoryItemDto.Name;
                    categoryItem.Name_OtherLanguage = updateCategoryItemDto.Name_OtherLanguage;
                    categoryItem.CategoryId = updateCategoryItemDto.CategoryId;
                    categoryItem.Status = updateCategoryItemDto.Status;

                    Update(categoryItem);
                    var result = await SaveChangesAsync();
                    if (result.Success)
                        return ServiceResponse<GetCategoryItemDto>.Succeeded(mapper.Map<GetCategoryItemDto>(categoryItem), "Category item updated successfully.");
                    return ServiceResponse<GetCategoryItemDto>.Failed(null, "Category item update failed!");
                }
                else
                    return ServiceResponse<GetCategoryItemDto>.NotFound(null, "Can't find Category item with Id = " + categoryItem.Id + " !");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetCategoryItemDto>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<PagedList<GetCategoryItemDto>>> Search(string value, UserParams? userParams)
        {
            try
            {
                var categoryItems = Get().Where(p => p.Name.Contains(value) ||
                                            p.Name_OtherLanguage.Contains(value) ||
                                            p.Category.Name.Contains(value))
                    .ProjectTo<GetCategoryItemDto>(mapper.ConfigurationProvider);
                var result = await PagedList<GetCategoryItemDto>.CreatePageAsync(categoryItems, userParams);
                return ServiceResponse<PagedList<GetCategoryItemDto>>.Succeeded(result, "Category items retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<PagedList<GetCategoryItemDto>>.Failed(null, ex.Message);
            }
        }

    }
}
