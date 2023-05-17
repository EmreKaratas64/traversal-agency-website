using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.ViewComponents.Home
{
    public class StatisticsInHome : ViewComponent
    {
        private readonly UserManager<AppUser> _appUser;

        public StatisticsInHome(UserManager<AppUser> appUser)
        {
            _appUser = appUser;
        }

        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.Rotations = c.Destinations.Count();
            ViewBag.guides = c.Guides.Count();
            ViewBag.Customers = _appUser.GetUsersInRoleAsync("User").Result.Count();
            ViewBag.References = c.Testimonials.Count();
            return View();
        }
    }
}
