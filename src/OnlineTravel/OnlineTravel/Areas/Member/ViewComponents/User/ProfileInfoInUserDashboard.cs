using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Areas.Member.ViewComponents.User
{
    public class ProfileInfoInUserDashboard : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileInfoInUserDashboard(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUser = await _userManager.FindByEmailAsync(User.Identity?.Name);
            if (currentUser == null) return View();
            return View(currentUser);
        }
    }
}
