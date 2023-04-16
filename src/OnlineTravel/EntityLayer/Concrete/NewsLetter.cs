using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class NewsLetter
    {
        [Key]
        public int NewsletterID { get; set; }

        public string? Mail { get; set; }
    }
}
