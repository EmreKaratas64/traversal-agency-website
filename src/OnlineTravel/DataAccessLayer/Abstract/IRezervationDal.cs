

using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IRezervationDal : IGenericDal<Rezervation>
    {
        List<Rezervation> GetRezervationsWithDestinationByUser(int userId);
    }
}
