using System.ComponentModel.DataAnnotations;

namespace OnlineTravel.Models
{
    public class MailRequest
    {
        [Required(ErrorMessage = "Receiver name cannot be empty")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Receiver mail cannot be empty")]
        [EmailAddress(ErrorMessage = "Receiver mail is invalid")]
        public string? ReceiverMail { get; set; }

        [Required(ErrorMessage = "Subject cannot be empty")]
        public string? Subject { get; set; }

        [Required(ErrorMessage = "Message content cannot be empty")]
        public string? MailBody { get; set; }
    }
}
