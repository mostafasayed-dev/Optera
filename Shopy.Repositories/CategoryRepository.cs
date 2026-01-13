using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Optera.DataAccess;
using Optera.DTOs.Category;
using Optera.DTOs.CategoryItem;
using Optera.DTOs.City;
using Optera.Infrastructure.Interfaces;
using Optera.Models;
using Optera.Repositories.Base;
using Optera.Utils.Pagination;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly IMapper mapper;

        public CategoryRepository(DBContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(context, httpContextAccessor)
        {
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<PagedList<GetCategoryDto>>> GetCategories(UserParams? userParams)
        {
            try
            {
                var categories = Get().OrderBy(x => x.Name).ProjectTo<GetCategoryDto>(mapper.ConfigurationProvider);
                var result = await PagedList<GetCategoryDto>.CreatePageAsync(categories, userParams);
                return ServiceResponse<PagedList<GetCategoryDto>>.Succeeded(result, "Categories retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<PagedList<GetCategoryDto>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<PagedList<GetCategoryDto>>> Search(string value, UserParams? userParams)
        {
            try
            {
                var categories = Get().Where(p => p.Name.Contains(value) ||
                                            p.Description.Contains(value))
                    .ProjectTo<GetCategoryDto>(mapper.ConfigurationProvider);
                var result = await PagedList<GetCategoryDto>.CreatePageAsync(categories, userParams);
                return ServiceResponse<PagedList<GetCategoryDto>>.Succeeded(result, "Categories retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<PagedList<GetCategoryDto>>.Failed(null, ex.Message);
            }
        }
    }
}
