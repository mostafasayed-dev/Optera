using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.Category
{
    public class GetCategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
