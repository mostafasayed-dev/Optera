using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Optera.DataAccess;
using Optera.DTOs.Customer;
using Optera.DTOs.Employee;
using Optera.Infrastructure.Interfaces;
using Optera.Models;
using Optera.Repositories.Base;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly DBContext dbContext;
        private readonly IMapper mapper;
        private readonly ICustomerIdentificationRepository customerIdentificationRepository;
        private readonly ICustomerContactPersonRepository customerContactPersonRepository;

        public CustomerRepository(DBContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper, 
            ICustomerIdentificationRepository customerIdentificationRepository,
            ICustomerContactPersonRepository customerContactPersonRepository) : base(context, httpContextAccessor)
        {
            this.dbContext = context;
            this.mapper = mapper;
            this.customerIdentificationRepository = customerIdentificationRepository;
            this.customerContactPersonRepository = customerContactPersonRepository;
        }

        public async Task<ServiceResponse<GetCustomerDto>> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            try
            {
                var customer = mapper.Map<Customer>(createCustomerDto);
                customer.Code = GenerateReferenceNumber("CUS");
                Add(customer);

                if (customer.CustomerIdentifications != null
                    && customer.CustomerIdentifications.Count > 0)
                {
                    customerIdentificationRepository.AddCustomerIdentifications(customer.CustomerIdentifications);
                }

                if (customer.CustomerContactPersons != null
                    && customer.CustomerContactPersons.Count > 0)
                {
                    customerContactPersonRepository.AddCustomerContactPerson(customer.CustomerContactPersons);
                }

                var result = await SaveChangesAsync();

                if (result.Success)
                    return ServiceResponse<GetCustomerDto>.Succeeded(mapper.Map<GetCustomerDto>(customer), "Customer created successfully");

                return ServiceResponse<GetCustomerDto>.Failed(null, "Customer creation failed!");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetCustomerDto>.Failed(null, ex.Message);
            }
        }

        public Customer AddCustomer(CreateCustomerDto createCustomerDto)
        {
            var customer = mapper.Map<Customer>(createCustomerDto);
            customer.Code = GenerateReferenceNumber("CUS");
            Add(customer);
            return customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            Update(customer);
            return customer;
        }

        public async Task<Customer> GetCustomer(long id)
        {
            var customer = await GetByIdAsync(id);
            return customer;
        }

        
    }
}
