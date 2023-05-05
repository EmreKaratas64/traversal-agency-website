using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]/{id?}")]
    public class UserController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

        public IActionResult UserDashboard()
        {
            var destinations = destinationManager.TGetAll().OrderByDescending(x => x.DestinationID).ToList();
            return View(destinations);
        }
    }
}
