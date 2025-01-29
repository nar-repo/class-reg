using System.ComponentModel.DataAnnotations;



namespace ActivityRegister.Models
{
    public class Registration
    {
        public int Id { get; set; }

        public int ActivityId { get; set; }
        
        public int UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
    }
}
