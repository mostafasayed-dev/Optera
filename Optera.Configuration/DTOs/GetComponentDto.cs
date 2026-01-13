using System.ComponentModel.DataAnnotations;

namespace Optera.Configuration.DTOs
{
    public class GetComponentDto
    {
        public required string Name { get; set; }
        public string? Title { get; set; }
        public string Creator { get; set; }
        public string Updator { get; set; }
    }
}
