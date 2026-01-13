namespace Optera.Query.DTOs.Miscellaneous
{
    public class GetCountry
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Name_OtherLanguage { get; set; } = default!;
        public string ISOCode { get; set; } = default!;
        public string Creator { get; set; } = default!;
        public string Updater { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = default!;
        public DateTime UpdatedAt { get; set; } = default!;
        public string Status { get; set; } = default!;
    }
}
