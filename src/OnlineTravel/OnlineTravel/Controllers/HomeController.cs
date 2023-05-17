using BusinessLayer.Abstract;
using DTOLayer.DTOs.ContactDTOs;
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
        private readonly IContactService _contactService;

        public HomeController(ILogger<HomeController> logger, IContactService contactService)
        {
            _logger = logger;
            _contactService = contactService;
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
        public IActionResult AboutPage(ContactMessageAddDto contact)
        {
            if (ModelState.IsValid)
            {
                Contact cont = new Contact()
                {
                    Name = contact.Name,
                    Description = contact.Description,
                    Mail = contact.Mail,
                    Status = true,
                    ContactDate = DateTime.Now
                };
                _contactService.TAdd(cont);
                TempData["MessageSuccess"] = "We got your message, thanks";
                return RedirectToAction("ShowHome");
            }
            TempData["MessageFail"] = "Message could not be sent";
            return View(contact);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}