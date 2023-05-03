using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineTravel.Areas.Member.Controllers
{
    [Area("Member")]
    public class RezervationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

        RezervationManager reservationManager = new RezervationManager(new EfRezervationDal());

        private readonly UserManager<AppUser> _userManager;

        public RezervationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IActionResult> UserReservations()
        {
            var currentUser = await _userManager.FindByEmailAsync(User.Identity?.Name);
            var userReservations = reservationManager.GetReservationswithDestinationForUser(currentUser.Id);
            if (userReservations.Count == 0)
                TempData["NoRecord"] = "You haven't have any rezervations yet. To make a rezervation you can check our tours";
            return View(userReservations);
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in destinationManager.TGetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public IActionResult NewReservation(Rezervation p)
        {
            p.AppUserId = _userManager.FindByEmailAsync(User.Identity?.Name).Result.Id;
            p.Status = EnumRezervationStatus.OdemeBekleniyor;
            reservationManager.TAdd(p);
            return RedirectToAction("UserDashboard", "User");
        }
    }
}
