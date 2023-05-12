using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.NotificationDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public IActionResult ShowNotifications()
        {
            var notifications = _mapper.Map<List<NotificationListDto>>(_notificationService.TGetAll());
            return View(notifications);
        }

        [HttpGet]
        public IActionResult AddNotification() => View();

        [HttpPost]
        public IActionResult AddNotification(NotificationAddDto model)
        {
            if (ModelState.IsValid)
            {
                _notificationService.TAdd(new Notification()
                {
                    Subject = model.Subject,
                    Description = model.Description,
                    Date = DateTime.Now
                });
                return RedirectToAction("AdminDashboard", "Dashboard");
            }
            return View(model);
        }
    }
}
