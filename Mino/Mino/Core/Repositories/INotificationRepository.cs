using Mino.Core.Models;
using System.Collections.Generic;

namespace Mino.Core.Repositories
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetUserNotifications(string userId);
        void Add(Notification notification);
    }
}
