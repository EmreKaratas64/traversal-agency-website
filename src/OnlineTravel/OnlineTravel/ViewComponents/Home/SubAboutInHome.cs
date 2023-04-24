using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.ViewComponents.Home
{
    public class SubAboutInHome : ViewComponent
    {
        SubAboutManager subAboutManager = new SubAboutManager(new EfSubAboutDal());

        public IViewComponentResult Invoke()
        {
            var values = subAboutManager.TGetAll();
            return View(values);
        }
    }
}
