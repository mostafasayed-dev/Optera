using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Optera.DTOs.Core
{
    public class GetDataTableColumnDto
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public bool Sortable { get; set; } = true;
        public bool Visible { get; set; } = true;
        public bool DisplayCurrency { get; set; } = false;
        public string Color { get; set; }
        public bool IsCheck { get; set; } = false;
        public string Datatype { get; set; }
        public int Order { get; set; }
    }
}
