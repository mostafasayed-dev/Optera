using System.Text.Json.Serialization;

namespace Optera.GraphQL.Models
{
    public class User
    {
        public string? Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public int Locked { get; set; }
    }
}
