
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IRezervationService : IGenericService<Rezervation>
    {
        List<Rezervation> GetReservationswithDestinationForUser(int userId);
    }
}
