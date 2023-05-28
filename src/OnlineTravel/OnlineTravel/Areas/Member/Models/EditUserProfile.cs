using System.ComponentModel.DataAnnotations;

namespace OnlineTravel.Areas.Member.Models
{
    public class EditUserProfile
    {
        public string? name { get; set; }

        public string? surname { get; set; }

        public IFormFile? Image { get; set; }

        public string? password { get; set; }

        [Compare("password", ErrorMessage = "Passwords does not match!")]
        public string? passwordConfirm { get; set; }

        public bool passwordChange { get; set; }
    }
}
