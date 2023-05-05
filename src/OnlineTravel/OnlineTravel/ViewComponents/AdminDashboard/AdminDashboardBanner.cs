using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.ViewComponents.AdminDashboard
{
    public class AdminDashboardBanner : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
