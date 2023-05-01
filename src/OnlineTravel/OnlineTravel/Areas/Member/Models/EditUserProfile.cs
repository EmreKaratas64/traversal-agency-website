using System.ComponentModel.DataAnnotations;

namespace OnlineTravel.Areas.Member.Models
{
    public class EditUserProfile
    {
        public string? name { get; set; }

        public string? surname { get; set; }

        public IFormFile? Image { get; set; }

        [Required(ErrorMessage = "Please enter a mail address")]
        [EmailAddress(ErrorMessage = "Please enter a vaild mail address")]
        public string? mail { get; set; }

        public string? password { get; set; }

        public string? passwordConfirm { get; set; }

        public bool passwordChange { get; set; }
    }
}
