using Optera.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Models
{
    public class Category : BaseModel
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<CategoryItem> CategoryItems { get; set; }
    }
}
