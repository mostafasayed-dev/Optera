namespace Optera.Miscellaneous.DTOs.Country
{
    public class UpdateCountry
    {
        public string? Name { get; set; } = default!;
        public string? Name_OtherLanguage { get; set; } = default!;
        public string? ISOCode { get; set; } = default!;
        public string? Status { get; set; } = default!;
    }
}
