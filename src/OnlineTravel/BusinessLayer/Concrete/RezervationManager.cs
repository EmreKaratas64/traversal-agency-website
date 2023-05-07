
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class RezervationManager : IRezervationService
    {
        IRezervationDal _rezervationDal;

        public RezervationManager(IRezervationDal rezervationDal)
        {
            _rezervationDal = rezervationDal;
        }

        public Rezervation TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Rezervation> GetReservationswithDestinationForUser(int userId)
        {
            return _rezervationDal.GetRezervationsWithDestinationByUser(userId);
        }

        public void TAdd(Rezervation entity)
        {
            _rezervationDal.Insert(entity);
        }

        public List<Rezervation> TGetAll()
        {
            return _rezervationDal.GetAll();
        }

        public void TUpdate(Rezervation entity)
        {
            _rezervationDal.Update(entity);
        }

        public void TDelete(Rezervation entity)
        {
            throw new NotImplementedException();
        }
    }
}
