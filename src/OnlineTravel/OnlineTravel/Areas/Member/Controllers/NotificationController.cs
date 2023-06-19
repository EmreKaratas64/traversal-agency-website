using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "User")]
    [Route("Member/[controller]/[action]/{id?}")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IActionResult DisplayNotifications()
        {
            var notifications = _notificationService.TGetAll();
            if (notifications.Count == 0)
                TempData["NoNotification"] = "No notification so far!";
            return View(notifications);
        }
    }
}
