

using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class NewsLetterManger : INewsLetterService
    {
        INewsLetterDal _newsLetterDal;

        public NewsLetterManger(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }

        public NewsLetter TGetByID(int id)
        {
            return _newsLetterDal.GetByID(id);
        }

        public void TAdd(NewsLetter entity)
        {
            _newsLetterDal.Insert(entity);
        }

        public List<NewsLetter> TGetAll()
        {
            return _newsLetterDal.GetAll();
        }

        public void TUpdate(NewsLetter entity)
        {
            _newsLetterDal.Update(entity);
        }
    }
}
