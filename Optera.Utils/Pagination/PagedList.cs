using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;

namespace Optera.Utils.Pagination
{
    public class PagedList<T> : List<T>
    {
        public PagedList(IEnumerable<T> items, int count, int pageNmber, int pageSize, string sortType = "asc", string sortField = null)
        {
            CurrentPage = pageNmber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            PageSize = pageSize;
            TotalCount = count;
            SortType = sortType;
            SortField = sortField;
            Items = items;
            AddRange(items);
        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public string SortType { get; set; }
        public string SortField { get; set; }
        public IEnumerable<T> Items { get; set; }

        public static async Task<PagedList<T>> CreatePageAsync(IQueryable<T> source, UserParams? userParams)
        {
            try
            {
                if (!string.IsNullOrEmpty(userParams.SortField))
                {
                    var sortExpression = $"{userParams.SortField} {userParams.SortType}";
                    source = source.OrderBy(sortExpression);
                }

                var count = await source.CountAsync();
                var items = await source.Skip((userParams.PageNumber - 1) * userParams.PageSize).Take(userParams.PageSize).ToListAsync();
                return new PagedList<T>(items, count, userParams.PageNumber, userParams.PageSize);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
