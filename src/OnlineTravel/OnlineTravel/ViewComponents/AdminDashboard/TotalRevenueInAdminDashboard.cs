using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.ViewComponents.AdminDashboard
{
    public class TotalRevenueInAdminDashboard : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
