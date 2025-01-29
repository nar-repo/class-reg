using System.ComponentModel.DataAnnotations;


namespace ActivityRegister.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string? ActivityName { get; set; }
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public string? ProviderName { get; set; }
        public string? Location { get; set; }
        public int Capacity { get; set; }
    }

}
