using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.User
{
    public class ResetPasswordDto
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
