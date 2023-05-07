using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;


namespace BusinessLayer.Concrete
{
    public class DestinationManager : IDestinationService
    {
        IDestinationDal _destinationDal;

        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public Destination TGetByID(int id)
        {
            return _destinationDal.GetByID(id);
        }

        public void TAdd(Destination entity)
        {
            _destinationDal.Insert(entity);
        }

        public List<Destination> TGetAll()
        {
            return _destinationDal.GetAll();
        }

        public void TUpdate(Destination entity)
        {
            _destinationDal.Update(entity);
        }

        public void TDelete(Destination entity)
        {
            throw new NotImplementedException();
        }
    }
}
