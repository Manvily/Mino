using Mino.Models;
using System.Collections.Generic;

namespace Mino.ViewModels
{
    public class SidebarViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public Project Project { get; set; }
        public Tag Tag { get; set; }
    }
}