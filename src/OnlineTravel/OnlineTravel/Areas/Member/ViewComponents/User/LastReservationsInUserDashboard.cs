using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Areas.Member.ViewComponents.User
{
    public class LastReservationsInUserDashboard : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IRezervationService _rezervationService;

        public LastReservationsInUserDashboard(UserManager<AppUser> userManager, IRezervationService rezervationService)
        {
            _userManager = userManager;
            _rezervationService = rezervationService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string mail)
        {
            var currentUser = await _userManager.FindByEmailAsync(mail);
            var userReservations = _rezervationService.GetReservationswithDestinationForUser(currentUser.Id).OrderByDescending(x => x.ReservationID).Take(5).ToList();
            return View(userReservations);
        }
    }
}
