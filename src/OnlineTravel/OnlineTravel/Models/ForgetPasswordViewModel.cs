using System.ComponentModel.DataAnnotations;

namespace OnlineTravel.Models
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Please enter a mail address")]
        [EmailAddress(ErrorMessage = "Please enter a valid mail address")]
        public string? Email { get; set; }
    }
}
