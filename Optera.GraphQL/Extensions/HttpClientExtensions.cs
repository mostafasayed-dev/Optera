using Optera.GraphQL.Pagination;
using Optera.GraphQL.Response;
using System.Text.Json;

namespace Optera.GraphQL.Extensions
{
    public static class HttpClientExtensions
    {
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        /// <summary>
        /// Sends a GET request and deserializes the content into ServiceResponse<T> regardless of status code.
        /// </summary>
        public static async Task<ServiceResponse<T>?> GetServiceResponseAsync<T>(
            this HttpClient httpClient,
            string requestUri,
            UserParams? userParams = null)
        {
            if (userParams != null)
            {
                requestUri += $"?pageNumber={userParams?.PageNumber}";
                requestUri += $"&pageSize={userParams?.PageSize}";
                if(!string.IsNullOrEmpty(userParams?.SortType))
                    requestUri += $"&sortType={userParams?.SortType}";
                if (!string.IsNullOrEmpty(userParams?.SortField))
                    requestUri += $"&sortField={userParams?.SortField}";
            }

            using var response = await httpClient.GetAsync(requestUri);
            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(content))
                return default;

            return JsonSerializer.Deserialize<ServiceResponse<T>>(content, _jsonOptions);
        }
    }
}
