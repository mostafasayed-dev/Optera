using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.Core
{
    public class GetComponentFormDto
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string Model { get; set; }

        public ICollection<GetComponentFormControlDto> ComponentFormControls { get; set; }
    }
}
