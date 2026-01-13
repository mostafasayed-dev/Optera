using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Models
{
    public class User : IdentityUser<int>
    {
        //public string Status { get; set; } = "Active";
        //public DateTime CreatedAt { get; set; } = DateTime.Now;
        //public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool Locked { get; set; } = false;
        public Employee Employee { get; set; }
    }
}
