namespace Optera.Miscellaneous.DTOs.Country
{
    public class CreateCountry
    {
        public required string Name { get; set; }
        public string? Name_OtherLanguage { get; set; }
        public string? ISOCode { get; set; }
    }
}
