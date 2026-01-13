using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.Core
{
    public class GetDataTableDto
    {
        public required string Name { get; set; }
        public string? Title { get; set; }
        public int ItemsPerPage { get; set; }
        public ICollection<GetDataTableColumnDto> Columns { get; set; }
    }
}
