using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Optera.DTOs.Employee
{
    public class GetEmployeeDto
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Mobile { get; set; }
        public long NationalityId { get; set; }
        public string? HomeAddress { get; set; }
        public DateTime JoiningDate { get; set; }
        public long PositionId { get; set; }
        public long CountryId { get; set; }
        public long CityId { get; set; }
        public long RegionId { get; set; }
        public string? Image { get; set; }
        public string? Signature { get; set; }
        public int UserId { get; set; }
    }
}
