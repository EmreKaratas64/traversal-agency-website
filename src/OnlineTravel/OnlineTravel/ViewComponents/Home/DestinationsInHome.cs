using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.ViewComponents.Home
{
    public class DestinationsInHome:ViewComponent
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

        public IViewComponentResult Invoke()
        {
            var destinations = destinationManager.TGetAll();
            return View(destinations);
        }
    }
}
