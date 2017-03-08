using System.ComponentModel.DataAnnotations;

namespace Mino.Core.Models
{
    public class Notification
    {
        public int Id { get; private set; }

        [Required]
        public string UserId { get; set; }

        public bool IsRead { get; set; }

        public NotificationType Type { get; set; }

        [Required]
        public Tasks Task { get; set; }

        public ApplicationUser User { get; private set; }

        public void MakeAsRead()
        {
            IsRead = true;
        }
    }
}