using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TestimonailManager : ITestimonialService
    {
        ITestimonialDal _testimonialDal;

        public TestimonailManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public Testimonial GetById(int id)
        {
            return _testimonialDal.Get(id);
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
