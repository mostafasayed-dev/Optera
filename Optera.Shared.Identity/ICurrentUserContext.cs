namespace Optera.Shared.Identity
{
    public interface ICurrentUserContext
    {
        /// <summary>
        /// The current user's unique ID (from JWT "sub").
        /// Returns null if not available (e.g., background tasks).
        /// </summary>
        string? UserId { get; }
        string? UserName { get; }
    }
}
