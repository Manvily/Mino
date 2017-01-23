using System;
using System.ComponentModel.DataAnnotations;

namespace Mino.Models
{
    public class Tasks
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime? DateTime { get; set; }

        public int? TagId { get; set; }

        public int? ProjectId { get; set; }

        [Required]
        public string UserId { get; set; }

        public bool IsDone { get; set; }

        public Tag Tag { get; set; }

        public Project Project { get; set; }
    }
}