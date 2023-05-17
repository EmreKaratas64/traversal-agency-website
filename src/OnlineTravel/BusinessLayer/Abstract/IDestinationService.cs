using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IDestinationService : IGenericService<Destination>
    {
        List<Destination> TGetDestinationsByName(string p);
    }
}
