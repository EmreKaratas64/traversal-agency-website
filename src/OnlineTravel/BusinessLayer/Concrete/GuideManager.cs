using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class GuideManager : IGuideService
    {
        IGuideDal _guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        public Guide TGetByID(int id)
        {
            return _guideDal.GetByID(id);
        }

        public void TAdd(Guide entity)
        {
            _guideDal.Insert(entity);
        }

        public List<Guide> TGetAll()
        {
            return _guideDal.GetAll();
        }

        public void TUpdate(Guide entity)
        {
            _guideDal.Update(entity);
        }

        public void TDelete(Guide entity)
        {
            throw new NotImplementedException();
        }
    }
}
