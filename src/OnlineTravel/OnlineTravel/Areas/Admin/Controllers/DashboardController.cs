using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class DashboardController : Controller
    {
        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}
