using Optera.DTOs.Customer;
using Optera.Models;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<ServiceResponse<GetCustomerDto>> CreateCustomer(CreateCustomerDto createCustomerDto);
        public Customer AddCustomer(CreateCustomerDto createCustomerDto);
        public Customer UpdateCustomer(Customer customer);
        public Task<Customer> GetCustomer(long id);
    }
}
