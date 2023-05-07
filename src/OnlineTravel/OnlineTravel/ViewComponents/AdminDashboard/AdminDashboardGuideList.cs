using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.ViewComponents.AdminDashboard
{
    public class AdminDashboardGuideList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
