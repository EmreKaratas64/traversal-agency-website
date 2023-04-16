using Microsoft.AspNetCore.Mvc;
using OnlineTravel.Models;
using System.Diagnostics;

namespace OnlineTravel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult ShowHome()
        {
            return View();
        }

        public PartialViewResult HeaderPartial() => PartialView();

        public PartialViewResult LeftBarPartial() => PartialView();

        public PartialViewResult FooterPartial() => PartialView();

        public PartialViewResult ScriptsPartial() => PartialView();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}