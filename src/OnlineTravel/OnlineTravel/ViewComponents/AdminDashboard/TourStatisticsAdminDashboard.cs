using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.ViewComponents.AdminDashboard
{
    public class TourStatisticsAdminDashboard : ViewComponent
    {
        private readonly IRezervationService _rezervationService;

        public TourStatisticsAdminDashboard(IRezervationService rezervationService)
        {
            _rezervationService = rezervationService;
        }

        public IViewComponentResult Invoke()
        {
            var last5reservations = _rezervationService.GetAllReservationswithDestinations().OrderByDescending(x => x.ReservationID).Take(5).ToList();
            return View(last5reservations);
        }
    }
}
