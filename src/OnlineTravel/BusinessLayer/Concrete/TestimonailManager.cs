using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class TestimonailManager : ITestimonialService
    {
        ITestimonialDal _testimonialDal;

        public TestimonailManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public Testimonial TGetByID(int id)
        {
            return _testimonialDal.GetByID(id);
        }

        public void TAdd(Testimonial entity)
        {
            _testimonialDal.Insert(entity);
        }

        public List<Testimonial> TGetAll()
        {
            return _testimonialDal.GetAll();
        }

        public void TUpdate(Testimonial entity)
        {
            _testimonialDal.Update(entity);
        }
    }
}
