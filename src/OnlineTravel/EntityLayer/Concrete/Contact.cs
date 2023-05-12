using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Mail { get; set; }

        public DateTime ContactDate { get; set; }

        public bool? Status { get; set; }
    }
}
