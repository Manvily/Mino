using System.ComponentModel.DataAnnotations;

namespace Mino.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Color { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}