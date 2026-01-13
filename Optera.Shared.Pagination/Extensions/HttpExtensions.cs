using Microsoft.AspNetCore.Http;
using Optera.Shared.Pagination.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Optera.Shared.Pagination.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, int currentPage,
                                        int itemsPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPages);
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var paginationJson = JsonSerializer.Serialize(paginationHeader, options);
            response.Headers["Pagination"] = paginationJson;
            response.Headers.Append("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
