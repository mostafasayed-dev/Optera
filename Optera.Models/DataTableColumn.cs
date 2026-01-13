using Optera.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Models
{
    public class DataTableColumn : BaseModel
    {
        public required string Name { get; set; }
        public long DataTableId { get; set; }
        public DataTable DataTable { get; set; }
        public required string Text { get; set; }
        public bool Sortable { get; set; } = true;
        public bool Visible { get; set; } = true;
        public bool DisplayCurrency { get; set; } = false;
        public string? Color { get; set; }
        public bool IsCheck { get; set; } = false;
        public string? Datatype { get; set; }
        public required int Order { get; set; }

    }
}
