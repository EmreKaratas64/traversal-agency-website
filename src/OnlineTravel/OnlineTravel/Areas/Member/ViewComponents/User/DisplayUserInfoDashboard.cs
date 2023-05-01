using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Areas.Member.ViewComponents.User
{
    public class DisplayUserInfoDashboard : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public DisplayUserInfoDashboard(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUser = await _userManager.FindByEmailAsync(User.Identity?.Name);
            return View(currentUser);
        }
    }
}
