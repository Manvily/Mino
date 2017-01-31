using System;
using System.ComponentModel.DataAnnotations;

namespace Mino.Models
{
    public class Tasks
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You cant add empty task.")]
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

        public int Priority { get; set; }

        public void Modify(string name, int? projectId = null, int? tagId = null, DateTime? dateTime = null)
        {
            Name = name;
            ProjectId = projectId;
            TagId = tagId;
            DateTime = dateTime;
        }
    }
}