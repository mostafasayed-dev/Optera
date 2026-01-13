using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.CategoryItem
{
    public class GetCategoryItemDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Name_OtherLanguage { get; set; }
        public string CategoryName { get; set; }
        public string CategoryId { get; set; }
        public string Status { get; set; }
    }
}
