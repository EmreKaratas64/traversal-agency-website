using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IDestinationDal : IGenericDal<Destination>
    {
        List<Destination> GetDestinationsByName(string p);
    }
}
