using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class GuidesController : Controller
    {
        private readonly IGuideService _guideService;

        public GuidesController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult ListGuides()
        {
            var guides = _guideService.TGetAll();
            return View(guides);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            _guideService.TAdd(guide);
            return RedirectToAction("ListGuides");
        }

        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var guide = _guideService.TGetByID(id);
            if (guide == null) return NotFound();
            return View(guide);
        }

        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            _guideService.TUpdate(guide);
            return RedirectToAction("ListGuides");
        }

        public IActionResult ChangeGuideStatus(int id)
        {
            var guide = _guideService.TGetByID(id);
            switch (guide.status)
            {
                case false:
                    guide.status = true;
                    break;
                case true:
                    guide.status = false;
                    break;
            }
            _guideService.TUpdate(guide);
            return RedirectToAction("ListGuides");
        }
    }
}
