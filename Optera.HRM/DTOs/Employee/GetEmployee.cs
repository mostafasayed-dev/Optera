namespace Optera.HRM.DTOs.Employee
{
    public class GetEmployee
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public char Gender { get; set; } = 'M';
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
    }
}
