using AutoMapper;
using Optera.DTOs.CustomerIdentification;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.MappingProfiles
{
    public class CustomerIdentificationProfile : Profile
    {
        public CustomerIdentificationProfile()
        {
            CreateMap<CreateCustomerIdentificationDto, CustomerIdentification>();
            CreateMap<CustomerIdentification, GetCustomerIdentificationDto>();
        }
    }
}
