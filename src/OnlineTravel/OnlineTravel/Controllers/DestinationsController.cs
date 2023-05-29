using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace OnlineTravel.Controllers
{
    // ctrl + M + G viewdan controllere
    [AllowAnonymous]
    public class DestinationsController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

        public IActionResult ShowDestinations(int page = 1)
        {
            var values = destinationManager.TGetAll().Where(y => y.Status == true).ToPagedList(page, 8);
            return View(values);
        }

        public IActionResult ShowDestinationDetails(int id)
        {
            ViewBag.Id = id;
            var destination = destinationManager.TGetByID(id);
            if (destination.Status == false) return NotFound();
            return View(destination);
        }
    }
}
