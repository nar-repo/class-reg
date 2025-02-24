using System.ComponentModel.DataAnnotations;


namespace ActivityRegister.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Email { get; set; } = null;

        public List<Registration> Registrations { get; set; } = new();
        public List<Waitlist> Waitlists { get; set; } = new(); // Navigation property: One-to-many with Waitlist
    }
}


