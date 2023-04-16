using System.ComponentModel.DataAnnotations;


namespace EntityLayer.Concrete
{
    public class Guide
    {
        [Key]
        public int GuideID { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public string? TwitterUrl { get; set; }

        public string? InstagramUrl { get; set; }

        public bool status { get; set; }
    }
}