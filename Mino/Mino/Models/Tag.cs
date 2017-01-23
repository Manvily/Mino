using System.ComponentModel.DataAnnotations;

namespace Mino.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}