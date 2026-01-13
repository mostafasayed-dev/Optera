using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Optera.DTOs.Core
{
    public class GetMenuItemDto
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string? Title { get; set; }
        public string? Icon { get; set; }
        //public IconDto Icon { get; set; }
        public string? Link { get; set; }
        public string? Url { get; set; }
        public string? Target { get; set; }
        public string? Data { get; set; }
        public bool? Home { get; set; }
        public bool? Group { get; set; }
        public bool? Expanded { get; set; }
        public bool? Hidden { get; set; }
        public int Order { get; set; }
        public List<GetMenuItemDto> children { get; set; } = new();
    }

    public class IconDto
    {
        public string Icon { get; set; }
        public string Pack { get; set; }
    }
}
