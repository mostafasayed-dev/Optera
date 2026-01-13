namespace Optera.Miscellaneous.DTOs.Country
{
    public class GetCountry
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Name_OtherLanguage { get; set; } = default!;
        public string ISOCode { get; set; } = default!;
        public string Status { get; set; } = default!;
    }
}
