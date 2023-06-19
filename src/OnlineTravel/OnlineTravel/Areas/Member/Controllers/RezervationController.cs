using BusinessLayer.Abstract;
using DTOLayer.DTOs.ReservationDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace OnlineTravel.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "User")]
    [Route("Member/[controller]/[action]/{id?}")]
    public class RezervationController : Controller
    {
        private readonly IRezervationService _rezervationService;
        private readonly IDestinationService _destinationService;

        private readonly UserManager<AppUser> _userManager;

        public RezervationController(UserManager<AppUser> userManager, IDestinationService destinationService, IRezervationService rezervationService)
        {
            _userManager = userManager;
            _destinationService = destinationService;
            _rezervationService = rezervationService;
        }



        public async Task<IActionResult> UserReservations()
        {
            var currentUser = await _userManager.FindByEmailAsync(User.Identity?.Name);
            var userReservations = _rezervationService.GetReservationswithDestinationForUser(currentUser.Id).OrderByDescending(x => x.ReservationID).ToList();
            if (userReservations.Count == 0)
                TempData["NoRecord"] = "You haven't have any rezervations yet. To make a rezervation you can check our tours";
            return View(userReservations);
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in _destinationService.TGetAll().Where(x => x.Status == true)
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public IActionResult NewReservation(ReservationAddDto p)
        {
            if (ModelState.IsValid)
            {
                Rezervation reservation = new Rezervation()
                {
                    PersonCount = p.PersonCount,
                    Description = p.Description,
                    DestinationID = p.DestinationID,
                    ReservastionDate = p.ReservationDate
                };
                reservation.AppUserId = _userManager.FindByEmailAsync(User.Identity?.Name).Result.Id;
                reservation.Status = EnumRezervationStatus.OdemeBekleniyor;
                _rezervationService.TAdd(reservation);
                return RedirectToAction("UserDashboard", "User");
            }
            List<SelectListItem> values = (from x in _destinationService.TGetAll().Where(x => x.Status == true)
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View(p);
        }

        public async Task<IActionResult> CancelReservation(int id)
        {
            var reservation = _rezervationService.TGetByID(id);
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            if (reservation == null || reservation.Status == EnumRezervationStatus.Onaylandi || reservation.AppUserId != user.Id) return BadRequest();
            else
            {
                reservation.Status = EnumRezervationStatus.IptalEdildi;
                _rezervationService.TUpdate(reservation);
                return RedirectToAction("UserReservations");
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateReservation(int id)
        {
            var reservation = _rezervationService.TGetByID(id);
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            if (reservation == null || reservation.AppUserId != user.Id) return NotFound();
            ReservationUpdateDto model = new ReservationUpdateDto()
            {
                ReservationID = id,
                PersonCount = reservation.PersonCount,
                Description = reservation.Description,
                ReservationDate = reservation.ReservastionDate
            };
            List<SelectListItem> values = (from x in _destinationService.TGetAll().Where(x => x.Status == true)
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View(model);
        }


        [HttpPost]
        public IActionResult UpdateReservation(ReservationUpdateDto p)
        {
            List<SelectListItem> values = (from x in _destinationService.TGetAll().Where(x => x.Status == true)
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationID.ToString()
                                           }).ToList();
            var reservation = _rezervationService.TGetByID(p.ReservationID);
            if (reservation == null) return NotFound();
            if (ModelState.IsValid)
            {
                reservation.PersonCount = p.PersonCount;
                reservation.Description = p.Description;
                reservation.DestinationID = p.DestinationID;
                reservation.ReservastionDate = p.ReservationDate;
                _rezervationService.TUpdate(reservation);
                return RedirectToAction("UserReservations");
            }

            ViewBag.v = values;
            return View(p);
        }
    }
}
