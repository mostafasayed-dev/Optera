using Elsa.Identity.Models;
using Optera.Tasks.Services.Interfaces;
using System.Net.Http.Headers;

namespace Optera.Tasks.Services
{
    public class ElsaClient : IElsaClient
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;

        public ElsaClient(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
        }

        /// <summary>
        /// Reports a task as completed.
        /// </summary>
        /// <param name="taskId">The ID of the task to complete.</param>
        /// <param name="result">The result of the task.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        public async Task ReportTaskCompletedAsync(string taskId, object? result = default, CancellationToken cancellationToken = default)
        {
            
            var token = await Login(
                configuration.GetSection("Elsa:Username").Value!,
                configuration.GetSection("Elsa:Password").Value!);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var url = new Uri($"tasks/{taskId}/complete", UriKind.Relative);
            var request = new { Result = result };
            await httpClient.PostAsJsonAsync(url, request, cancellationToken);
        }

        private async Task<string?> Login(string username, string password, CancellationToken cancellationToken = default)
        {
            var url = "identity/login";

            var request = new
            {
                username = username,
                password = password
            };

            var response = await httpClient.PostAsJsonAsync(url, request, cancellationToken);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<LoginResponse>(cancellationToken: cancellationToken);

            return result?.AccessToken;
        }
    }
}
