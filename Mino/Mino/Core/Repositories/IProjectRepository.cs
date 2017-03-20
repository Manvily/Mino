using Mino.Core.Models;
using System.Collections.Generic;

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