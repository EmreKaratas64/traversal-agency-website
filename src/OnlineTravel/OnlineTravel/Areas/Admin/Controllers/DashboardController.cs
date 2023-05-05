using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}
