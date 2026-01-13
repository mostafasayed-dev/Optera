using AutoMapper;
using Optera.HRM.DTOs.Employee;
using Optera.HRM.Models;

namespace Optera.HRM.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, GetEmployee>();
            CreateMap<CreateEmployee, Employee>();
        }
    }
}
