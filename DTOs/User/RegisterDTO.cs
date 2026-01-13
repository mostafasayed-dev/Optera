using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Optera.DTOs.User
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeGender { get; set; }
        [Required]
        public DateTime EmployeeDateOfBirth { get; set; }
        [Required]
        public long EmployeeNationalityId { get; set; }
        [Required]
        public DateTime EmployeeJoiningDate { get; set; }
        public long EmployeePositionId { get; set; }
        [Required]
        public List<string> Roles { get; set; } = new();
    }
}
