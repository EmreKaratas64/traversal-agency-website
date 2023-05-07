using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class About2Manager : IAbout2Service
    {
        IAbout2Dal _about2Dal;

        public About2Manager(IAbout2Dal about2Dal)
        {
            _about2Dal = about2Dal;
        }

        public About2 TGetByID(int id)
        {
            return _about2Dal.GetByID(id);
        }

        public void TAdd(About2 entity)
        {
            _about2Dal.Insert(entity);
        }

        public List<About2> TGetAll()
        {
            return _about2Dal.GetAll();
        }

        public void TUpdate(About2 entity)
        {
            _about2Dal.Update(entity);
        }

        public void TDelete(About2 entity)
        {
            throw new NotImplementedException();
        }
    }
}
