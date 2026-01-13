using AutoMapper;
using Microsoft.AspNetCore.Http;
using Optera.DataAccess;
using Optera.DTOs.Country;
using Optera.DTOs.Employee;
using Optera.Infrastructure.Interfaces;
using Optera.Models;
using Optera.Repositories.Base;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace Optera.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly DBContext dbContext;
        private readonly IMapper mapper;

        public EmployeeRepository(DBContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(context, httpContextAccessor)
        {
            this.dbContext = context;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<GetEmployeeDto>> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            try
            {
                var employee = mapper.Map<Employee>(createEmployeeDto);
                Add(employee);
                var result = await SaveChangesAsync();

                if (result.Success)
                    return ServiceResponse<GetEmployeeDto>.Succeeded(mapper.Map<GetEmployeeDto>(employee), "Employee created successfully");

                return ServiceResponse<GetEmployeeDto>.Failed(null, "Employee creation failed!");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetEmployeeDto>.Failed(null, ex.Message);
            }
        }
    }
}
