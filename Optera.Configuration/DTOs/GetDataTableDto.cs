namespace Optera.Configuration.DTOs
{
    public class GetDataTableDto
    {
        public string Name { get; set; } = default!;
        public string Title { get; set; } = default!;
        public int ItemsPerPage { get; set; }
        public ICollection<GetDataTableColumnDto> Columns { get; set; } = default!;
    }
}
