using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.ViewComponents.AdminDashboard
{
    public class AdminDashboardGuideList : ViewComponent
    {
        private readonly IGuideService _guideService;

        public AdminDashboardGuideList(IGuideService guideService)
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
