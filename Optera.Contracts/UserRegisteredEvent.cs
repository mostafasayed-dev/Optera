namespace Optera.Contracts
{
    public class UserRegisteredEvent
    {
        public string Id { get; set; }
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
