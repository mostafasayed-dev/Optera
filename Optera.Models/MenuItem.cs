using Optera.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Optera.Models
{
    public class MenuItem : BaseModel
    {
        public long? ParentId { get; set; }
        public string? Title { get; set; }
        public string? Icon { get; set; }
        public string? Link { get; set; }
        public string? Url { get; set; }
        public string? Target { get; set; }
        public string? Data { get; set; }
        public bool? Home { get; set; }
        public bool? Group { get; set; }
        public bool? Expanded { get; set; }
        public bool? Hidden { get; set; }
        public int Order { get; set; }

        [ForeignKey(nameof(ParentId))]
        public MenuItem Parent { get; set; }
        public ICollection<MenuItem> Children { get; set; } = new List<MenuItem>();
    }
}
