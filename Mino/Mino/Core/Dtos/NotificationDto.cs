using Mino.Core.Models;

namespace Mino.Core.Dtos
{
    public class NotificationDto
    {
        public NotificationType Type { get; set; }
        public Tasks Task { get; set; }
    }
}