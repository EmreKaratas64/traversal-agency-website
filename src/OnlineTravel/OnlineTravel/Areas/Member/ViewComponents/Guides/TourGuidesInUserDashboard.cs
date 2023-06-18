using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Areas.Member.ViewComponents.Guides
{
    public class TourGuidesInUserDashboard : ViewComponent
    {
        GuideManager guideManager = new GuideManager(new EfGuideDal());

        public IViewComponentResult Invoke()
        {
            var guides = guideManager.TGetAll().Where(x => x.status == true).ToList();
            return View(guides);
        }
    }
}
