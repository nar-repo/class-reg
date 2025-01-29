using System.ComponentModel.DataAnnotations;



namespace ActivityRegister.Models
{
    public class Waitlist
    {
        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public int WaitListPosition { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAddedToWaitlist { get; set; }

    }
}
