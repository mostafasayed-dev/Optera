namespace Optera.Events
{
    public record UserRegisteredEvent(
        string Id,
        string UserName,
        string Email
    );

    public record UserLoggedInEvent(
    string Id,
    string UserName,
    string Email
);
}