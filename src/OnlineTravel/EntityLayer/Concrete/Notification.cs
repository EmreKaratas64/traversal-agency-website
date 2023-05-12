

using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }

        public string? Subject { get; set; }

        public string? Description { get; set; }

        public DateTime Date { get; set; }
    }
}
