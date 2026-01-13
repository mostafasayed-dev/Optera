namespace Optera.GraphQL.Interface.Pagination
{
    public class UserParams
    {
        public int PageNumber { get; set; } = 1;
        public string SortType { get; set; } = "asc";
        public string? SortField { get; set; } = "";

        int _pageSize = 100;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > _pageSize) ? _pageSize : value;
        }
    }
}
