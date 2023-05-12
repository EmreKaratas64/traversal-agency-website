using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly IContactService _contactService;

        public MessageController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult ShowContactMessages()
        {
            var contacts = _contactService.TGetAll();
            return View(contacts);
        }
    }
}
