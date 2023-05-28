using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
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

        public IActionResult DeleteContactMessage(int id)
        {
            var message = _contactService.TGetByID(id);
            if (message == null) return NotFound();
            else
            {
                _contactService.TDelete(message);
                return RedirectToAction("ShowContactMessages");
            }
        }
    }
}
