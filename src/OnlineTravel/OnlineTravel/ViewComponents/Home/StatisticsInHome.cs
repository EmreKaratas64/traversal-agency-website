using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.ViewComponents.Home
{
    public class StatisticsInHome : ViewComponent
    {
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.Rotations = c.Destinations.Count();
            ViewBag.guides = c.Guides.Count();
            ViewBag.happyCustomers = c.Testimonials.Select(x => x.client).Distinct().Count();
            return View();
        }
    }
}
