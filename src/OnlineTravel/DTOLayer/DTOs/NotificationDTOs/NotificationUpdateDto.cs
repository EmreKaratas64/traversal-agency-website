namespace DTOLayer.DTOs.NotificationDTOs
{
    public class NotificationUpdateDto
    {
        public int NotificationID { get; set; }

        public string? Subject { get; set; }

        public string? Description { get; set; }

        public DateTime Date { get; set; }
    }
}
