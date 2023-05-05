using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.ViewComponents.AdminDashboard
{
    public class AdminDashboardStatistics : ViewComponent
    {
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.tours = c.Destinations.Count();
            ViewBag.users = c.Users.Count();
            return View();
        }
    }
}
