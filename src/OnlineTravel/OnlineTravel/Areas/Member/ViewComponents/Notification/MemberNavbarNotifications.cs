using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Areas.Member.ViewComponents.Notification
{
    public class MemberNavbarNotifications : ViewComponent
    {
        private readonly INotificationService _notificationService;

        public MemberNavbarNotifications(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
        {
            var notifications = _notificationService.TGetAll().OrderByDescending(x => x.NotificationID).Take(4).ToList();
            return View(notifications);
        }
    }
}
