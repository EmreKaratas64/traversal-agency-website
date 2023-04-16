using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.ViewComponents.Home
{
    public class HomeSlider:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
