using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Optera.DTOs.Employee
{
    public class CreateEmployeeDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(1)]
        [RegularExpression("^(M|F)$", ErrorMessage = "Gender must be M or F.")]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Mobile { get; set; }
        [Required]
        public  long NationalityId { get; set; }
        public string? HomeAddress { get; set; }
        [Required]
        public DateTime JoiningDate { get; set; }
        [Required]
        public long PositionId { get; set; }
        public long? CountryId { get; set; }
        public long? CityId { get; set; }
        public long? RegionId { get; set; }
        public string? Image { get; set; }
        public string? Signature { get; set; }

        public int? UserId { get; set; }
    }
}
