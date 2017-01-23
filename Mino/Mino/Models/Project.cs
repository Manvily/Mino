﻿using System.ComponentModel.DataAnnotations;

namespace Mino.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}