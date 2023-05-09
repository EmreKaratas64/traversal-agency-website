using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace OnlineTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class ReservationsController : Controller
    {
        private readonly IRezervationService _rezervationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IDestinationService _destinationService;

        public ReservationsController(IRezervationService rezervationService, UserManager<AppUser> userManager, IDestinationService destinationService)
        {
            _rezervationService = rezervationService;
            _userManager = userManager;
            _destinationService = destinationService;
        }

        public IActionResult ReservationsPage()
        {
            List<SelectListItem> values = (from x in _destinationService.TGetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }

        public IActionResult DisplayReservations()
        {
            var reservations = JsonConvert.SerializeObject(_rezervationService.GetAllReservationswithDestinations(), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(reservations);

        }

        public IActionResult FindReservation(int ReservationID) // parametre ajax'da verlien data daki parametre ismi ile aynı olmalıdır!
        {
            var reservation = _rezervationService.GetReservationwithDestinationById(ReservationID);
            var jsonReservation = JsonConvert.SerializeObject(reservation, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
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

        public IActionResult DeleteReservation(int id)
        {
            var value = _rezervationService.TGetByID(id);
            _rezervationService.TDelete(value);
            return NoContent();
        }


        public IActionResult UpdateReservation(Rezervation reservation)
        {
            reservation.AppUserId = _userManager.FindByEmailAsync(User.Identity?.Name).Result.Id;
            reservation.Status = EnumRezervationStatus.OdemeBekleniyor;
            _rezervationService.TUpdate(reservation);
            var jsonReservation = JsonConvert.SerializeObject(reservation);
            return Json(jsonReservation);
        }

        public IActionResult KeepReservation(int id)
        {
            var reservation = _rezervationService.TGetByID(id);
            reservation.Status = EnumRezervationStatus.OnayBekleniyor;
            _rezervationService.TUpdate(reservation);
            TempData["KeepingSuccess"] = "Reservation status is switched to Waiting Approval!";
            return RedirectToAction("ReservationsPage");
        }

        public IActionResult ApproveReservation(int id)
        {
            var reservation = _rezervationService.TGetByID(id);
            reservation.Status = EnumRezervationStatus.Onaylandi;
            _rezervationService.TUpdate(reservation);
            TempData["ApprovalSuccess"] = "Reservations is approved successfully!";
            return RedirectToAction("ReservationsPage");
        }
    }
}
