using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.ViewComponents.Home
{
    public class DestinationsInHome : ViewComponent
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

        [HttpGet]
        public IViewComponentResult Invoke()
        {
            //List<SelectListItem> values = (from x in destinationManager.TGetAll()
            //                               select new SelectListItem
            //                               {
            //                                   Text = x.City,
            //                                   Value = x.City
            //                               }).ToList();
            //ViewBag.v = values;
            var destinations = destinationManager.TGetAll().Where(y => y.Status == true).OrderByDescending(x => x.DestinationID).Take(6).ToList();
            return View(destinations);
        }
    }
}
