using Optera.Shared.Domain;

namespace Optera.Query.Models
{
    public class Country : BaseModel
    {
        public required string Name { get; set; }
        public string? Name_OtherLanguage { get; set; }
        public string? ISOCode { get; set; }
    }
}
