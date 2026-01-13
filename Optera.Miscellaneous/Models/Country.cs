using Optera.Miscellaneous.Models.Base;

namespace Optera.Miscellaneous.Models
{
    public class Country : BaseModel
    {
        public required string Name { get; set; }
        public string? Name_OtherLanguage { get; set; }
        public string? ISOCode { get; set; }
    }
}
