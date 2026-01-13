using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.CategoryItem
{
    public class UpdateCategoryItemDto
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string? Name_OtherLanguage { get; set; }
        public long CategoryId { get; set; }
        public string Status { get; set; }
    }
}
