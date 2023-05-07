using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.ViewComponents.AdminDashboard
{
    public class TourStatisticsAdminDashboard : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
