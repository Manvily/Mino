using Microsoft.AspNet.Identity;
using Mino.Core.Dtos;
using Mino.Core.Models;
using Mino.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Mino.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;

        public NotificationsController()
        {
            var context = new ApplicationDbContext();
            _unitOfWork = new UnitOfWork(context);
        }
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var notifications = _unitOfWork.Notifications
                .GetUserNotifications(User.Identity.GetUserId());

            return notifications.Select(n => new NotificationDto()
            {
                Type = n.Type,
                Task = n.Task
            });
        }

        [HttpPost]
        public IHttpActionResult CreateOverdueNotifications()
        {
            var userId = User.Identity.GetUserId();
            var overdueTasks = _unitOfWork.Tasks.GetOverdueTasksWithoutNotification(userId);

            foreach (var task in overdueTasks)
            {
                var notification = new Notification
                {
                    UserId = userId,
                    IsRead = false,
                    Type = NotificationType.TaskOverdue,
                    Task = task
                };
                task.SetNotification();
                _unitOfWork.Notifications.Add(notification);
            }
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult MakeAsRead()
        {
            var notifications = _unitOfWork.Notifications
                .GetUserNotifications(User.Identity.GetUserId());

            foreach (var notification in notifications)
                notification.MakeAsRead();
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
