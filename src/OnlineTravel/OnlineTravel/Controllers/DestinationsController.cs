using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Controllers
{
    public class DestinationsController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

        public IActionResult ShowDestinations()
        {
            var values = destinationManager.TGetAll();
            return View(values);
        }
    }
}
