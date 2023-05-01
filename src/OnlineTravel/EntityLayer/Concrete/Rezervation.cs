
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Rezervation
    {
        [Key]
        public int ReservationID { get; set; }
        public int AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public string? PersonCount { get; set; }
        public DateTime ReservastionDate { get; set; }
        public string? Description { get; set; }
        public EnumRezervationStatus Status { get; set; }
        public int DestinationID { get; set; }
        public Destination? Destination { get; set; }
    }

    public enum EnumRezervationStatus
    {
        OdemeBekleniyor = 0,
        OnayBekleniyor = 1,
        Onaylandi = 2,
        IptalEdildi = 3
    }
}
