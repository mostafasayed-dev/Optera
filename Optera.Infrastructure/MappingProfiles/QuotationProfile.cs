using AutoMapper;
using Optera.DTOs.Quotation;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.MappingProfiles
{
    public class QuotationProfile : Profile
    {
        public QuotationProfile()
        {
            CreateMap<CreateQuotationDto, Quotation>();
            CreateMap<UpdateQuotationDto, Quotation>()
                    //.ForMember(dest => dest.Status, opt => opt.Ignore())
                    .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                    .ForMember(dest => dest.Creator, opt => opt.Ignore())
                    .ForMember(dest => dest.EmployeeId, opt => opt.Ignore())
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Quotation, GetQuotationDto>();
        }
    }
}
