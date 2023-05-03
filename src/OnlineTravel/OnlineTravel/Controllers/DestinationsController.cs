using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Controllers
{
    // ctrl + M + G viewdan controllere
    public class DestinationsController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

        public IActionResult ShowDestinations()
        {
            var values = destinationManager.TGetAll();
            return View(values);
        }

        public IActionResult ShowDestinationDetails(int id)
        {
            ViewBag.Id = id;
            var destination = destinationManager.TGetByID(id);
            return View(destination);
        }
    }
}
