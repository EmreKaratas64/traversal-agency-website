

using System.ComponentModel.DataAnnotations;

namespace OnlineTravel.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Please enter a password")]
        public string? password { get; set; }

        [Required(ErrorMessage = "Please confirm the password")]
        [Compare("password", ErrorMessage = "Passwords does not match!")]
        public string? confirmPassword { get; set; }
    }
}
