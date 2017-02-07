using System.Collections.Generic;
using Mino.Core.Models;

namespace Mino.Core.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<Tasks> GetUserTasksByProject(string userId, int? id);
        IEnumerable<Tasks> GetTodayTasks(string userId);
        IEnumerable<Tasks> GetNextWeekTasks(string userId);
        IEnumerable<Tasks> GetUserTasksByTag(string userId, int id);
        IEnumerable<Tasks> GetOverdueTasks(string userId);
        Tasks GetUserTask(string userId, int id);
        void Add(Tasks task);
        void Remove(Tasks task);
    }
}