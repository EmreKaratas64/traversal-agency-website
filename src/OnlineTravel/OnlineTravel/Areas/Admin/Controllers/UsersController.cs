using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IRezervationService _rezervationService;

        public UsersController(UserManager<AppUser> userManager, IRezervationService rezervationService)
        {
            _userManager = userManager;
            _rezervationService = rezervationService;
        }

        public IActionResult ListAllUsers()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        // BanUser metodu eklenilecek, önce Asp.NetUsers tablosuna status kolonu eklenmeli

        //[HttpGet]
        //public IActionResult EditUser(int id)
        //{
        //    var user = _userManager.FindByIdAsync(id.ToString());
        //    return View(user);
        //}

        //[HttpPost]
        //public async Task<IActionResult> EditUser(AppUser user)
        //{
        //    if (user == null) return NotFound();
        //    var result = await _userManager.UpdateAsync(user);
        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("ListAllUsers");
        //    }
        //    else
        //    {
        //        foreach (var item in result.Errors)
        //        {
        //            ModelState.AddModelError("", item.Description);
        //        }
        //    }
        //    return View(user);
        //}

        public IActionResult UserReservationHistory(int id)
        {
            var reservations = _rezervationService.GetReservationswithDestinationForUser(id);
            return View(reservations);
        }
    }
}
