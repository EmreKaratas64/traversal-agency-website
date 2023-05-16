using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }

        public string? Name { get; set; }

        public decimal Balance { get; set; }
    }
}
