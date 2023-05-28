using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineTravel.Models;

namespace OnlineTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/[controller]/[action]/{id?}")]
    public class AdminSettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminSettingsController(UserManager<AppUser> userManger)
        {
            _userManager = userManger;
        }

        [HttpGet]
        public async Task<IActionResult> ManageSettings()
        {
            var currentUser = await _userManager.FindByEmailAsync(User.Identity?.Name);
            if (currentUser == null) return NotFound();
            else
            {
                AdminSettings model = new AdminSettings()
                {
                    name = currentUser.Name,
                    surname = currentUser.Surname,
                };
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ManageSettings(AdminSettings model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);

            if (ModelState.IsValid)
            {
                user.Name = model.name;
                user.Surname = model.surname;
                if (model.passwordChange == true)
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("LogOut", "Account", new { area = "" });
                }
            }

            return View(model);
        }
    }
}
