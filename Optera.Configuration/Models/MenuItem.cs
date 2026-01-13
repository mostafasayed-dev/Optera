using Optera.Shared.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optera.Configuration.Models
{
    public class MenuItem : BaseModel
    {

        [MaxLength(50)]
        public string? Title { get; set; }

        [MaxLength(25)]
        public string? Icon { get; set; }

        [MaxLength(50)]
        public string? Link { get; set; }

        [MaxLength(50)]
        public string? Url { get; set; }

        [MaxLength(25)]
        public string? Target { get; set; }

        [MaxLength(25)]
        public string? Data { get; set; }

        public bool? Home { get; set; }

        public bool? Group { get; set; }

        public bool? Expanded { get; set; }

        public bool? Hidden { get; set; }

        public int Order { get; set; }

        public Guid? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public MenuItem Parent { get; set; }
        public ICollection<MenuItem> Children { get; set; } = new List<MenuItem>();
    }
}
