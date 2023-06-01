using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.ViewComponents.AdminDashboard
{
    public class AdminDashboardStatistics2 : ViewComponent
    {
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.comments = c.Comments.Count();
            ViewBag.reservations = c.Rezervations.Count();
            ViewBag.bestTour = c.Rezervations
                                .Join(c.Destinations,
                                    r => r.DestinationID,
                                    d => d.DestinationID,
                                    (r, d) => new { Reservation = r, Destination = d })
                                .GroupBy(rd => rd.Destination.City)
                                .OrderByDescending(g => g.Count())
                                .Select(g => g.Key)
                                .FirstOrDefault();
            return View();
        }
    }
}
