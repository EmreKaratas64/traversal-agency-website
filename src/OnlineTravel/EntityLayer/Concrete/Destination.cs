using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Destination
    {
        [Key]
        public int DestinationID { get; set; }

        public string? City { get; set; }

        public string? DayNight { get; set; }

        public double Price { get; set; }

        public string? Image { get; set; }

        public string? Description { get; set; }

        public int Capacity { get; set; }

        public bool Status { get; set; }

        public string? CoverImage { get; set; }

        public string? Details1 { get; set; }

        public string? Details2 { get; set; }

        public string? Image2 { get; set; }

        public List<Comment>? Comments { get; set; }
    }
}
