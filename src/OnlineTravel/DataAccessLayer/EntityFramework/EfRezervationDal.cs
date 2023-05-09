using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfRezervationDal : GenericRepository<Rezervation>, IRezervationDal
    {
        public List<Rezervation> GetAllReservationsWithDestination()
        {
            using (var c = new Context())
            {
                return c.Rezervations.Include(r => r.Destination).ToList();
            }
        }

        public Rezervation GetReservationByIdWithDestination(int Id)
        {
            using (var c = new Context())
            {
                return c.Rezervations.Include(c => c.Destination).Where(x => x.ReservationID == Id).FirstOrDefault();
            }
        }

        public List<Rezervation> GetRezervationsWithDestinationByUser(int userId)
        {
            using (var c = new Context())
            {
                return c.Rezervations.Include(x => x.Destination).Where(x => x.AppUserId == userId).ToList();
            }
        }
    }
}
