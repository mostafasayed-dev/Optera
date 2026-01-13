using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.Role
{
    public class CreateRoleClaimsDto
    {
        public int RoleId { get; set; }
        public string[] Authorizations { get; set; }
    }
}
