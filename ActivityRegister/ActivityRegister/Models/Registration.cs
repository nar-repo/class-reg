using System.ComponentModel.DataAnnotations;



namespace ActivityRegister.Models
{
    public enum RegistrationStatus
    {
        
        Pending,
        Registered,
        Waitlisted,
        Cancelled
    }


    public class Registration
    {
        public int Id { get; set; }
        
        public int? ActivityId { get; set; } //foreign key to ActicityId
        public int? UserId { get; set; } // foreign key to User class
        public User User { get; set; } = null!;
        public Activity Activity { get; set; } = null!;

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
        public RegistrationStatus Status { get; set; } = Models.RegistrationStatus.Pending;

        
    }
}
