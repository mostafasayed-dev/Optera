using Optera.Shared.Domain;
using System.ComponentModel.DataAnnotations;

namespace Optera.Configuration.Models
{
    public class DataTable : BaseModel
    {
        [MaxLength(100)]
        public required string Name { get; set; }
        [MaxLength(100)]
        public string? Title { get; set; }
        public int ItemsPerPage { get; set; } = 10;
        public ICollection<DataTableColumn> DataTableColumns { get; set; }
    }
}
