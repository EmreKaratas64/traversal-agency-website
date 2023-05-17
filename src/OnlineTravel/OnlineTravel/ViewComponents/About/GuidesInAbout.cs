using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.ViewComponents.About
{
    public class GuidesInAbout : ViewComponent
    {
        private readonly IGuideService _guideService;

        public GuidesInAbout(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IViewComponentResult Invoke()
        {
            var guides = _guideService.TGetAll();
            return View(guides);
        }
    }
}
