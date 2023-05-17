using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public List<Destination> GetDestinationsByName(string p)
        {
            using (var c = new Context())
            {
                return c.Destinations.Where(x => x.City == p).ToList();
            }
        }
    }
}
