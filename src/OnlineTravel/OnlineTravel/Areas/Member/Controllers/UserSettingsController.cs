using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineTravel.Areas.Member.Models;

namespace OnlineTravel.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "User")]
    [Route("Member/[controller]/[action]/{id?}")]
    public class UserSettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserSettingsController(UserManager<AppUser> userManger)
        {
            _userManager = userManger;
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var currentUser = await _userManager.FindByEmailAsync(User.Identity?.Name);
            if (currentUser == null) return NotFound();
            else
            {
                EditUserProfile model = new EditUserProfile()
                {
                    name = currentUser.Name,
                    surname = currentUser.Surname,
                };
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditUserProfile model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);
            if (ModelState.IsValid)
            {
                if (model.Image != null)
                {
                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(model.Image.FileName);
                    var imagename = Guid.NewGuid() + extension;
                    var savelocation = resource + "/wwwroot/userimages/" + imagename;
                    var stream = new FileStream(savelocation, FileMode.Create);
                    await model.Image.CopyToAsync(stream);
                    user.ImageUrl = imagename;
                }
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
