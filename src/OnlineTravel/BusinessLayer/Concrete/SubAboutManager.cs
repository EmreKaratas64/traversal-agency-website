using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class SubAboutManager : ISubAboutService
    {
        ISubAboutDal _subAboutDal;

        public SubAboutManager(ISubAboutDal subAboutDal)
        {
            _subAboutDal = subAboutDal;
        }

        public SubAbout TGetByID(int id)
        {
            return _subAboutDal.GetByID(id);
        }

        public void TAdd(SubAbout entity)
        {
            _subAboutDal.Insert(entity);
        }

        public List<SubAbout> TGetAll()
        {
            return _subAboutDal.GetAll();
        }

        public void TUpdate(SubAbout entity)
        {
            _subAboutDal.Update(entity);
        }

        public void TDelete(SubAbout entity)
        {
            throw new NotImplementedException();
        }
    }
}
