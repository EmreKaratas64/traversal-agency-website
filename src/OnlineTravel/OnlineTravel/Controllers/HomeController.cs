using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTravel.Models;
using System.Diagnostics;

namespace OnlineTravel.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        ContactManager contactManager = new ContactManager(new EfContactDal());

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult ShowHome()
        {
            //_logger.LogInformation("Home page showed");
            //_logger.LogError("Home page error");
            //_logger.LogWarning("Home page warning");
            return View();
        }

        public PartialViewResult HeaderPartial() => PartialView();

        public PartialViewResult LeftBarPartial() => PartialView();

        public PartialViewResult FooterPartial() => PartialView();

        public PartialViewResult ScriptsPartial() => PartialView();

        [HttpGet]
        public IActionResult AboutPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AboutPage(Contact contact)
        {
            contactManager.TAdd(contact);
            TempData["MessageSuccess"] = "We got your message, thanks";
            return RedirectToAction("ShowHome");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}