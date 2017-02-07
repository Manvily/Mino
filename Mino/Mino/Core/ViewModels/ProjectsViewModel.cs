using System.Collections.Generic;
using Mino.Core.Models;

namespace Mino.Core.ViewModels
{
    public class ProjectsViewModel
    {
        public IEnumerable<Project> Projects;

        public ProjectsViewModel(IEnumerable<Project> projects)
        {
            Projects = projects;
        }
    }
}