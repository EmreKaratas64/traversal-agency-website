using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class DestinationsController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

        public IActionResult DisplayDestinations()
        {
            var destinations = destinationManager.TGetAll();
            return View(destinations);
        }

        [HttpGet]
        public IActionResult AddNewDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewDestination(Destination model)
        {
            if (model.City == null || model.DayNight == null || model.Image == null || model.Image2 == null || model.CoverImage == null || model.Description == null || model.Details1 == null || model.Details2 == null)
                return BadRequest();

            model.Status = true;
            destinationManager.TAdd(model);
            return RedirectToAction("DisplayDestinations");
        }

        [HttpGet]
        public IActionResult EditTour(int id)
        {
            var destination = destinationManager.TGetByID(id);
            if (destination == null)
                return BadRequest();
            return View(destination);
        }

        [HttpPost]
        public IActionResult EditTour(Destination model)
        {
            if (model.City == null || model.DayNight == null || model.Image == null || model.Image2 == null || model.CoverImage == null || model.Description == null || model.Details1 == null || model.Details2 == null)
                return BadRequest();
            destinationManager.TUpdate(model);
            return RedirectToAction("DisplayDestinations");
        }
    }
}
