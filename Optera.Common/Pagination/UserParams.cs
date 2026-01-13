using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optera.Common.Pagination
{
    public class UserParams
    {
        //private const int MaxPageSize = 50;
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
