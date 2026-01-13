using Optera.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Optera.Models
{
    public class Authorization : BaseModel
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public long? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public Authorization Parent { get; set; }
        public int Order { get; set; }

        public ICollection<Authorization> Children { get; set; } = new List<Authorization>();
    }
}
