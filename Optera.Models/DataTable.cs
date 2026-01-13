using Optera.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Models
{
    public class DataTable : BaseModel
    {
        public required string Name { get; set; }
        public string? Title { get; set; }
        public int ItemsPerPage { get; set; } = 10;
        public ICollection<DataTableColumn> DataTableColumns { get; set; }
    }
}
