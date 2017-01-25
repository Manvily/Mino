using Mino.Models;
using System.Collections.Generic;

namespace Mino.ViewModels
{
    public class SidebarViewModel // TODO change name
    {
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}