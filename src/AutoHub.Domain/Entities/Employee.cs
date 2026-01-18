namespace AutoHub.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        // password will be hashed later
        public string PasswordHash { get; set; } = string.Empty;

        // Admin / Staff
        public string Role { get; set; } = "Staff";

        public bool IsActive { get; set; } = true;
    }
}
