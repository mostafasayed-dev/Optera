using Blazored.LocalStorage;
using Elsa.Studio.Login.Contracts;
using Microsoft.JSInterop;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;

namespace Optera.Elsa.Studio.Services
{
    public class IdentityAuthService : IAuthorizationService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly IJSRuntime _js;

        public IdentityAuthService(HttpClient httpClient, ILocalStorageService localStorage, IJSRuntime js)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _js = js;
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            var payload = new LoginDto
            {
                Email = email,
                Password = password
            };

            var response = await _httpClient.PostAsJsonAsync("api/auth/token", payload);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new InvalidOperationException($"Login failed: {error}");
            }

            var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();

            if (string.IsNullOrWhiteSpace(tokenResponse?.access_token))
                throw new InvalidOperationException("Token response invalid.");

            var token = tokenResponse.access_token;

            // Store JWT in local storage
            await _localStorage.SetItemAsStringAsync("access_token", token);
            await _localStorage.SetItemAsStringAsync("refresh_token", token);

            return token;
        }

        public Task<string?> GetTokenAsync()
        {
            return _localStorage.GetItemAsync<string>("access_token").AsTask();
        }

        public async Task RedirectToAuthorizationServer()
            => await _js.InvokeVoidAsync("location.replace", "/login");

        public Task ReceiveAuthorizationCode(string code, string? state, CancellationToken cancellationToken)
            => throw new NotImplementedException();
    }

    public class LoginDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }

    public class TokenResponse
    {
        public string access_token { get; set; } = string.Empty;
    }
}
