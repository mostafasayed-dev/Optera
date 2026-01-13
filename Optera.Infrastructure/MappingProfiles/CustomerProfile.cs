using AutoMapper;
using Optera.DTOs.Customer;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, Customer>();
            CreateMap<Customer, GetCustomerDto>()
                .ForMember(dest => dest.CustomerContactPersons,
                           opt => opt.MapFrom(src => src.CustomerContactPersons));
        }
    }
}
