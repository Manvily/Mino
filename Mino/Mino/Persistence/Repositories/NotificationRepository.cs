using Mino.Core.Models;
using Mino.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Mino.Persistence.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Notification> GetUserNotifications(string userId)
        {
            return _context.Notifications
                .Where(n =>
                !n.IsRead &&
                n.UserId == userId)
                .Include(t => t.Task)
                .ToList();
        }

        public void Add(Notification notification)
        {
            _context.Notifications.Add(notification);
        }
    }
}