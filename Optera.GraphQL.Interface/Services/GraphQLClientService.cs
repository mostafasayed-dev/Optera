using Optera.GraphQL.Interface.Enums;
using Optera.GraphQL.Interface.Pagination;
using Optera.GraphQL.Interface.Response;
using Optera.GraphQL.Interface.Services.Interfaces;
using System.Collections.Concurrent;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Optera.GraphQL.Interface.Services
{
    public class GraphQLClientService : IGraphQLClientService
    {
        private readonly HttpClient httpClient;
        private static readonly ConcurrentDictionary<string, string> _cache = new();

        public GraphQLClientService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ServiceResponse<T>?> ExecuteQueryAsync<T>(
            Queries query,
            object? variables = null,
            UserParams? userParams = null,
            CancellationToken cancellationToken = default)
        {
            var gqlVariables = new Dictionary<string, object>();
            if (userParams != null)
            {
                gqlVariables["userParams"] = new
                {
                    pageNumber = userParams.PageNumber,
                    pageSize = userParams.PageSize,
                    sortType = userParams.SortType,
                    sortField = userParams.SortField
                };
            }
            if (variables != null)
            {
                foreach (var prop in variables.GetType().GetProperties())
                    gqlVariables[prop.Name] = prop.GetValue(variables);
            }


            // Build request payload
            var gqlQuery = Get(query);
            var gqlRequest = new 
            { 
                query = gqlQuery, 
                variables = gqlVariables
            };

            var content = new StringContent(
                JsonSerializer.Serialize(gqlRequest),
                Encoding.UTF8,
                "application/json");

            // Execute POST request to GraphQL endpoint
            var response = await httpClient.PostAsync("", content, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var errorText = await response.Content.ReadAsStringAsync(cancellationToken);
                return ServiceResponse<T>.Failed(default, $"GraphQL request failed: {response.StatusCode} - {errorText}");
            }

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            using var jsonDoc = JsonDocument.Parse(json);

            // Handle GraphQL errors (errors array)
            if (jsonDoc.RootElement.TryGetProperty("errors", out var errorsNode))
            {
                var messages = string.Join("; ", errorsNode.EnumerateArray()
                    .Select(e => e.GetProperty("message").GetString()));
                return ServiceResponse<T>.Failed(default, $"GraphQL errors: {messages}");
            }

            // Extract data node
            if (!jsonDoc.RootElement.TryGetProperty("data", out var dataNode))
                return ServiceResponse<T>.Failed(default, "Invalid GraphQL response: missing 'data' property.");

            var firstProperty = dataNode.EnumerateObject().FirstOrDefault();
            if (firstProperty.Value.ValueKind == JsonValueKind.Null)
                return ServiceResponse<T>.Failed(default, $"GraphQL field '{firstProperty.Name}' returned null.");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };

            return JsonSerializer.Deserialize<ServiceResponse<T>>(firstProperty.Value.GetRawText(), options);
        }

        private string Get(Queries query)
        {
            var fileName = $"{query}.graphql";
            return GetByFileName(fileName);
        }

        private string GetByFileName(string fileName)
        {
            if (_cache.TryGetValue(fileName, out var cached))
                return cached;

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Queries", fileName);

            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"GraphQL query file not found: {fullPath}");

            var content = File.ReadAllText(fullPath);
            _cache[fileName] = content;
            return content;
        }
    }
}