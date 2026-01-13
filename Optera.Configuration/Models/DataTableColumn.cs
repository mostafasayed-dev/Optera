using Optera.Shared.Domain;
using System.ComponentModel.DataAnnotations;

namespace Optera.Configuration.Models
{
    public class DataTableColumn : BaseModel
    {
        [MaxLength(100)]
        public required string Name { get; set; }
        public Guid DataTableId { get; set; }
        public DataTable DataTable { get; set; }
        [MaxLength(100)]
        public required string Text { get; set; }
        public bool Sortable { get; set; } = true;
        public bool Visible { get; set; } = true;
        public bool DisplayCurrency { get; set; } = false;
        [MaxLength(25)]
        public string? Color { get; set; }
        public bool IsCheck { get; set; } = false;
        [MaxLength(25)]
        public string? Datatype { get; set; }
        public required int Order { get; set; }
    }
}
