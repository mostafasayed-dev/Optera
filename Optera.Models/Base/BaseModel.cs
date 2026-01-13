using Optera.Utils.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Models.Base
{
    public class BaseModel
    {
        public long Id { get; set; }
        public string Status { get; set; } = Optera.Utils.Models.Status.Active;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string Creator { get; set; } = "System";
        public string Updator { get; set; } = "System";
    }
}
