using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.ViewComponents.Home
{
    public class TestimonialsInHome : ViewComponent
    {
        TestimonailManager testimonailManager = new TestimonailManager(new EfTestimonialDal());

        public IViewComponentResult Invoke()
        {
            var testimonials = testimonailManager.TGetAll();
            return View(testimonials);
        }
    }
}
