using Mino.Core.Models;
using Mino.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Mino.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Project> GetUserProjects(string userId)
        {
            return _context.Projects
                .Where(x => x.UserId == userId)
                .ToList();
        }

        public Project GetUserProject(string userId, int id)
        {
            return _context.Projects.Single(x =>
            x.UserId == userId &&
            x.Id == id);
        }

        public void Add(Project project)
        {
            _context.Projects.Add(project);
        }

        public void Remove(Project project)
        {
            _context.Projects.Remove(project);
        }
    }
}