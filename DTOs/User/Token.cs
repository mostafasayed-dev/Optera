using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.User
{
    public class Token
    {
        public int UserId { get; set; }
        public string? JWT { get; set; }
        public double? Expires_in { get; set; }
    }
}
