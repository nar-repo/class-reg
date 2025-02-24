using System.ComponentModel.DataAnnotations;



namespace ActivityRegister.Models
{
    public class Waitlist
    {
        public int Id { get; set; }
        //public int? RegistrationId { get; set; }

        [Required] // Example data annotation (optional, but good practice)
        public int ActivityId { get; set; } // Foreign key to Activity
        public Activity Activity { get; set; } // Navigation property

        [Required]
        public int UserId { get; set; } // Foreign key to User
        public User User { get; set; } // Navigation property


        [DataType(DataType.Date)]
        public DateTime RequestDate { get; set; } //use OrderBy() to implement FIFO ->
                                                  // find the RegistrationId and change the status 
    }
}

