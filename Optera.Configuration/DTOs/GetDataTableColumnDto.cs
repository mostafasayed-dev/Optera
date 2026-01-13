namespace Optera.Configuration.DTOs
{
    public class GetDataTableColumnDto
    {
        public string Name { get; set; } = default!;
        public string Text { get; set; } = default!;
        public bool Sortable { get; set; } = true;
        public bool Visible { get; set; } = true;
        public bool DisplayCurrency { get; set; } = false;
        public string Color { get; set; } = default!;
        public bool IsCheck { get; set; } = false;
        public string Datatype { get; set; } = default!;
        public int Order { get; set; }
    }
}
