using System.Collections.Generic;
using Mino.Core.Models;

namespace Mino.Core.Repositories
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetUserProjects(string userId);
        Project GetUserProject(string userId, int id);
        void Add(Project project);
        void Remove(Project project);
    }
}