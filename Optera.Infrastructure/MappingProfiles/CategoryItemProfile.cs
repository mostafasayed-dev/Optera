using AutoMapper;
using Optera.DTOs.CategoryItem;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.MappingProfiles
{
    public class CategoryItemProfile : Profile
    {
        public CategoryItemProfile()
        {
            CreateMap<CategoryItem, GetCategoryItemDto>();
            CreateMap<CreateCategoryItemDto, CategoryItem>();
            CreateMap<UpdateCategoryItemDto, CategoryItem>();
            CreateMap<CategoryItem, GetCategoryItemListDto>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(x => x.Name));
        }
    }
}
