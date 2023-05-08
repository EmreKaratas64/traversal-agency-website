using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace OnlineTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class ReservationsController : Controller
    {
        private readonly IRezervationService _rezervationService;
        private readonly UserManager<AppUser> _userManager;

        public ReservationsController(IRezervationService rezervationService, UserManager<AppUser> userManager)
        {
            _rezervationService = rezervationService;
            _userManager = userManager;
        }

        public IActionResult ReservationsPage()
        {
            return View();
        }

        public IActionResult DisplayReservations()
        {
            var reservations = JsonConvert.SerializeObject(_rezervationService.TGetAll());
            return Json(reservations);

        }

        public IActionResult FindReservation(int ReservationID)
        {
            var reservation = _rezervationService.TGetByID(ReservationID);
            var jsonReservation = JsonConvert.SerializeObject(reservation);
            return Json(jsonReservation);
        }

        [HttpPost]
        public IActionResult AddReservation(Rezervation reservation)
        {
            reservation.Status = EnumRezervationStatus.OdemeBekleniyor;
            reservation.AppUserId = _userManager.FindByEmailAsync(User.Identity?.Name).Result.Id;
            _rezervationService.TAdd(reservation);
            var jsonReservation = JsonConvert.SerializeObject(reservation);
            return Json(jsonReservation);
        }
    }
}
