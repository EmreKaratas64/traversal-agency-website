using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineTravel.Models;

namespace OnlineTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IRezervationService _rezervationService;
        private readonly RoleManager<AppRole> _roleManager;

        public UsersController(UserManager<AppUser> userManager, IRezervationService rezervationService, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _rezervationService = rezervationService;
            _roleManager = roleManager;
        }

        public IActionResult ListAllUsers()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        public async Task<IActionResult> BanUserAccount(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null) return NotFound();
            else
            {
                if (user.Status == true)
                {
                    user.Status = false;
                    await _userManager.UpdateAsync(user);
                }
                else
                {
                    user.Status = true;
                    await _userManager.UpdateAsync(user);
                }
                return RedirectToAction("ListAllUsers");
            }

        }

        [HttpGet]
        public async Task<IActionResult> ManageRoles(int Id)
        {
            var user = await _userManager.FindByIdAsync(Id.ToString());
            var roles = _roleManager.Roles.ToList();

            TempData["UserId"] = user.Id;
            ViewBag.UserNameSurname = user.Name + " " + user.Surname;

            var user_roles = await _userManager.GetRolesAsync(user);

            List<AssignRoleViewModel> model = new List<AssignRoleViewModel>();

            foreach (var item in roles)
            {
                AssignRoleViewModel m = new AssignRoleViewModel();
                m.RoleID = item.Id;
                m.RoleName = item.Name;
                m.Exists = user_roles.Contains(item.Name);
                model.Add(m);
            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> ManageRoles(List<AssignRoleViewModel> p)
        {
            var userId = (int)TempData["UserId"];
            var user = await _userManager.FindByIdAsync(userId.ToString());

            foreach (var item in p)
            {
                if (item.Exists)
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                else
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
            }
            return RedirectToAction("ListAllUsers");
        }





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
