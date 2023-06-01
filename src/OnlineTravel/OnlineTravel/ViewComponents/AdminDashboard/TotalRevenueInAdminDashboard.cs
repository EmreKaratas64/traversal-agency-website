using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.ViewComponents.AdminDashboard
{
    public class TotalRevenueInAdminDashboard : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public TotalRevenueInAdminDashboard(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var admins = await _userManager.GetUsersInRoleAsync("Admin");
            return View(admins);
        }
    }
}
