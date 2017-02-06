using Mino.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Mino.ViewModels
{
    public class SidebarViewModel
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public Project Project { get; set; }
        public Tag Tag { get; set; }
        public Tasks Task { get; set; }
        public IEnumerable<SelectListItem> ColorType { get; set; }
    }
}