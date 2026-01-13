using Optera.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Optera.Models
{
    public class CategoryItem : BaseModel
    {
        public required string Name { get; set; }
        public string? Name_OtherLanguage { get; set; }

        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
