using Elsa.Studio.Login.Contracts;
using Elsa.Studio.Login.Models;
using Optera.Elsa.Studio.Services;

namespace Optera.Elsa.Studio.Validator
{
    public class OpteraCredentialsValidator : ICredentialsValidator
    {
        private readonly IdentityAuthService _authService;

        public OpteraCredentialsValidator(IdentityAuthService authService)
        {
            _authService = authService;
        }

        public async ValueTask<ValidateCredentialsResult> ValidateCredentialsAsync(
            string username,
            string password,
            CancellationToken cancellationToken = default)
        {
            // Call your Optera.Identity login service to get JWT
            var token = await _authService.LoginAsync(username, password);

            if (!string.IsNullOrEmpty(token))
            {
                // Success
                return new ValidateCredentialsResult(true, token, token);
            }

            // Failure
            return new ValidateCredentialsResult(false, "Invalid username or password", null);
        }
    }
}
