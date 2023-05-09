
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IRezervationService : IGenericService<Rezervation>
    {
        List<Rezervation> GetReservationswithDestinationForUser(int userId);

        List<Rezervation> GetAllReservationswithDestinations();

        Rezervation GetReservationwithDestinationById(int Id);
    }
}
