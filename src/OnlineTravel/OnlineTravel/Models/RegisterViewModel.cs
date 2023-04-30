using System.ComponentModel.DataAnnotations;

namespace OnlineTravel.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string? name { get; set; }

        [Required(ErrorMessage = "Please enter a surname")]
        public string? surname { get; set; }

        [Required(ErrorMessage = "Please enter a mail address")]
        [EmailAddress(ErrorMessage = "Please enter a vaild mail address")]
        public string? email { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        public string? password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [Compare("password", ErrorMessage = "Passwords does not match")]
        public string? passwordConfirm { get; set; }
    }
}
