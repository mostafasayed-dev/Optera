using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optera.Miscellaneous.Models.Base
{
    public class BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string? Creator { get; set; }
        public string? Updater { get; set; }
        public string Status { get; set; } = "Active";
        [Timestamp]
        public byte[] RowVersion { get; set; } = default!;
    }
}
