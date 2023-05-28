using EntityLayer.Concrete;

namespace DTOLayer.DTOs.ReservationDTOs
{
    public class ReservationUpdateDto
    {
        public int ReservationID { get; set; }

        public string? PersonCount { get; set; }

        public string? Description { get; set; }

        public int DestinationID { get; set; }

        public Destination? Destination { get; set; }

        public DateTime ReservationDate { get; set; }
    }
}
