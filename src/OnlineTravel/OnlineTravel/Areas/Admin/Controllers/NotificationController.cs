using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.NotificationDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
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
                return RedirectToAction("ShowNotifications");
            }
            return View(model);
        }

        public IActionResult DeleteNotification(int id)
        {
            var notf = _notificationService.TGetByID(id);
            if (notf == null)
                return NotFound();
            else
                _notificationService.TDelete(notf);

            return RedirectToAction("ShowNotifications");
        }

        [HttpGet]
        public IActionResult UpdateNotification(int id)
        {
            var notification = _mapper.Map<NotificationUpdateDto>(_notificationService.TGetByID(id));
            if (notification == null) return NotFound();
            else
            {
                return View(notification);
            }
        }

        [HttpPost]
        public IActionResult UpdateNotification(NotificationUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _notificationService.TUpdate(new Notification
                {
                    NotificationID = model.NotificationID,
                    Subject = model.Subject,
                    Description = model.Description,
                    Date = DateTime.Now
                });
                return RedirectToAction("ShowNotifications");
            }
            return View(model);
        }
    }
}
