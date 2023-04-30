using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class UserController : Controller
    {
        public IActionResult UserDashboard()
        {
            return View();
        }
    }
}
