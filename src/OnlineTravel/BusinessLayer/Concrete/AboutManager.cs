
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public About TGetByID(int id)
        {
            return _aboutDal.GetByID(id);
        }

        public void TAdd(About entity)
        {
            _aboutDal.Insert(entity);
        }

        public List<About> TGetAll()
        {
            return _aboutDal.GetAll();
        }

        public void TUpdate(About entity)
        {
            _aboutDal.Update(entity);
        }

        public void TDelete(About entity)
        {
            throw new NotImplementedException();
        }
    }
}
