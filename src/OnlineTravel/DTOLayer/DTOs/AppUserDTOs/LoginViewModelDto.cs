using System.ComponentModel.DataAnnotations;

namespace OnlineTravel.Models
{
    public class LoginViewModelDto
    {
        [EmailAddress(ErrorMessage = "Please enter a valid mail address")]
        [Required(ErrorMessage = "Please enter a mail address")]
        public string? email { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        public string? password { get; set; }

        public bool rememberMe { get; set; }
    }
}
