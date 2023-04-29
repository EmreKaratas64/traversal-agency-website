using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.ViewComponents.About
{
    public class AboutSectionInAboutPage : ViewComponent
    {
        About2Manager about2Manager = new About2Manager(new EfAbout2Dal());

        public IViewComponentResult Invoke()
        {
            var about2 = about2Manager.TGetAll().OrderBy(x => x.About2ID).LastOrDefault();
            return View(about2);
        }
    }
}
