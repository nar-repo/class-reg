using System.ComponentModel.DataAnnotations;


namespace ActivityRegister.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string? ActivityName { get; set; }
        public string? Description { get; set; }
        public int Capacity { get; set; }

       // public bool IsWaitlisted { get; set; } = false;
        // if cap is full, set IsWaitlist to True, add a record to WaitList class

        public List<Registration> Registrations { get; set; } = new(); // Navigation property
        public List<Waitlist> Waitlists { get; set; } = new();
    }

}
