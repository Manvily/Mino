using Mino.Core.Models;
using Mino.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;

namespace Mino.Persistence.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Tasks> GetUserTasksByProject(string userId, int? id)
        {
            return _context.Tasks.Where(x =>
                    x.UserId == userId &&
                    !x.IsDone &&
                    x.ProjectId == id)
                    .OrderByDescending(a => a.Priority)
                .Include(p => p.Project)
                .Include(t => t.Tag)
                .ToList();
        }

        public IEnumerable<Tasks> GetUserTasksByTag(string userId, int id)
        {
            return _context.Tasks.Where(x =>
                    x.UserId == userId &&
                    !x.IsDone &&
                    x.TagId == id)
                    .OrderByDescending(a => a.Priority)
                .Include(p => p.Project)
                .Include(t => t.Tag)
                .ToList();
        }

        public IEnumerable<Tasks> GetTodayTasks(string userId)
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            return _context.Tasks.Where(x =>
                    x.UserId == userId &&
                    !x.IsDone &&
                    x.DateTime.HasValue &&
                    x.DateTime >= today &&
                    x.DateTime < tomorrow)
                    .OrderByDescending(a => a.Priority)
                .Include(p => p.Project)
                .Include(t => t.Tag)
                .ToList();
        }

        public IEnumerable<Tasks> GetNextWeekTasks(string userId)
        {
            var endOfWeek = DateTime.Today.AddDays(7);
            return _context.Tasks.Where(x =>
                    x.UserId == userId &&
                    !x.IsDone &&
                    x.DateTime >= DateTime.Today.Date &&
                    x.DateTime <= endOfWeek)
                    .OrderByDescending(a => a.Priority)
                .Include(p => p.Project)
                .Include(t => t.Tag)
                .ToList();
        }

        public IEnumerable<Tasks> GetOverdueTasks(string userId)
        {
            return _context.Tasks.Where(x =>
                    x.UserId == userId &&
                    !x.IsDone &&
                    x.DateTime < DateTime.Today)
                    .OrderByDescending(a => a.Priority)
                .Include(p => p.Project)
                .Include(t => t.Tag)
                .ToList();
        }

        public Tasks GetTask(string userId, int id)
        {
            return _context.Tasks.Single(g =>
                g.UserId == userId &&
                g.Id == id);
        }

        public void Add(Tasks task)
        {
            _context.Tasks.Add(task);
        }

        public void Remove(Tasks task)
        {
            _context.Tasks.Remove(task);
        }

        public IEnumerable<Tasks> SearchTasks(string userId, string query)
        {
            return _context.Tasks.Where(g =>
                    g.Name.Contains(query) &&
                    !g.IsDone &&
                    g.UserId == userId)
                    .OrderByDescending(a => a.Priority)
                .Include(t => t.Tag)
                .Include(p => p.Project)
                .ToList();
        }

        public IEnumerable<Tasks> GetOverdueTasksWithoutNotification(string userId)
        {
            return _context.Tasks.Where(a =>
                    !a.IsDone &&
                    !a.HasNotification &&
                    a.DateTime < DateTime.Today &&
                    a.UserId == userId)
                    .OrderByDescending(a => a.Priority)
                .Include(p => p.Project)
                .Include(t => t.Tag)
                .ToList();
        }
    }
}