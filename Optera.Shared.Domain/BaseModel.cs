using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optera.Shared.Domain
{
    public class BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string? Creator { get; set; }
        public string? Updater { get; set; }
        public string Status { get; set; } = "Active";
        [Timestamp]
        public byte[] RowVersion { get; set; } = default!;
    }
}
