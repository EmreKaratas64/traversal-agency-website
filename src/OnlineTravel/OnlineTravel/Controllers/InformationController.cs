using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
