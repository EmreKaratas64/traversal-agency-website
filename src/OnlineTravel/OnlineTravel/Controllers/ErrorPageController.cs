using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }
    }
}
