using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text;

namespace Optera.DTOs.Core
{
    public class GetAuthorizationDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public long? ParentId { get; set; }
        public int Order { get; set; }
        public bool? Selected { get; set; } = false;
        public List<GetAuthorizationDto> Children { get; set; } = new();
    }
}
