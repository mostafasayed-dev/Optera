using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.User
{
    public class GetUserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        //public string NormalizedUserName { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        //public string NormalizedEmail { get; set; }
        public int EmailConfirmed { get; set; }
        public int Locked { get; set; }
    }
}
