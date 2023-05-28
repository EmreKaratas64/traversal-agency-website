using System.ComponentModel.DataAnnotations;

namespace OnlineTravel.Models
{
    public class AdminSettings
    {
        public string? name { get; set; }

        public string? surname { get; set; }

        public string? password { get; set; }

        [Compare("password", ErrorMessage = "Passwords does not match!")]
        public string? passwordConfirm { get; set; }

        public bool passwordChange { get; set; }
    }
}
