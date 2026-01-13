using AutoMapper;
using Optera.DTOs.CustomerContactPerson;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.MappingProfiles
{
    public class CustomerContactPersonProfile : Profile
    {
        public CustomerContactPersonProfile()
        {
            CreateMap<CreateCustomerContactPersonDto, CustomerContactPerson>();
            CreateMap<CustomerContactPerson, GetCustomerContactPersonDto>();
        }
    }
}
