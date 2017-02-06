using Microsoft.AspNet.Identity;
using Mino.Models;
using Mino.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Mino.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private ApplicationDbContext _context;

        public TasksController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var tasks =
                _context.Tasks.Where(x =>
                    x.UserId == userId &&
                    !x.IsDone &&
                    x.ProjectId == null)
                    .Include(p => p.Project)
                    .Include(t => t.Tag)
                    .ToList();

            var viewModel = new TasksViewModel(tasks);

            return View("Index", viewModel);
        }

        public ActionResult Today()
        {
            var userId = User.Identity.GetUserId();
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            var tasks =
                _context.Tasks.Where(x =>
                    x.UserId == userId &&
                    !x.IsDone &&
                    x.DateTime.HasValue &&
                    x.DateTime >= today &&
                    x.DateTime < tomorrow)
                    .Include(p => p.Project)
                    .Include(t => t.Tag)
                    .ToList();

            var viewModel = new TasksViewModel(tasks, "Today");

            return View("Index", viewModel);
        }

        public ActionResult NextWeek()
        {
            var userId = User.Identity.GetUserId();
            var endOfWeek = DateTime.Today.AddDays(7);
            var tasks =
                _context.Tasks.Where(x =>
                    x.UserId == userId &&
                    !x.IsDone &&
                    x.DateTime >= DateTime.Today.Date &&
                    x.DateTime <= endOfWeek)
                    .Include(p => p.Project)
                    .Include(t => t.Tag)
                    .ToList();

            var week = new Dictionary<string, IEnumerable<Tasks>>
            {
                {
                    "Today",
                    GetTasksInDay(0, tasks)
                },
                {
                    "Tomorrow",
                    GetTasksInDay(1, tasks)
                },
                {
                    GetDayName(2),
                    GetTasksInDay(2, tasks)
                },
                {
                    GetDayName(3),
                    GetTasksInDay(3, tasks)
                },
                {
                    GetDayName(4),
                    GetTasksInDay(4, tasks)
                },
                {
                    GetDayName(5),
                    GetTasksInDay(5, tasks)
                },
                {
                    GetDayName(6),
                    GetTasksInDay(6, tasks)
                }
            };

            var viewModel = new WeeklyTasksViewModel
            {
                Tasks = week
            };

            return View(viewModel);
        }

        public string GetDayName(int days) =>
            DateTime.Today.AddDays(days).DayOfWeek.ToString();

        public IEnumerable<Tasks> GetTasksInDay(int days, IEnumerable<Tasks> tasks)
        {
            var startDay = DateTime.Today.AddDays(days);
            var endDay = startDay.AddDays(1);

            return tasks.Where(a =>
            a.DateTime >= startDay &&
            a.DateTime < endDay)
            .ToList();
        }

        public ActionResult Project(int projectId)
        {
            var userId = User.Identity.GetUserId();
            var tasks =
                _context.Tasks.Where(x =>
                    x.UserId == userId &&
                    !x.IsDone &&
                    x.ProjectId == projectId)
                    .Include(p => p.Project)
                    .Include(t => t.Tag)
                    .ToList();

            var viewModel = new TasksViewModel(tasks);

            return View("Index", viewModel);
        }

        public ActionResult Tag(int tagId)
        {
            var userId = User.Identity.GetUserId();
            var tasks =
                _context.Tasks.Where(x =>
                    x.UserId == userId &&
                    !x.IsDone &&
                    x.TagId == tagId)
                    .Include(p => p.Project)
                    .Include(t => t.Tag)
                    .ToList();

            var viewModel = new TasksViewModel(tasks);

            return View("Index", viewModel);
        }

        public ActionResult Overdue()
        {
            var userId = User.Identity.GetUserId();
            var tasks = _context.Tasks.Where(x =>
            x.UserId == userId &&
            !x.IsDone &&
            x.DateTime < DateTime.Today)
            .Include(p => p.Project)
            .Include(t => t.Tag)
            .ToList();

            var viewModel = new TasksViewModel(tasks, "Overdue");

            return PartialView("Index", viewModel);
        }

        [ChildActionOnly]
        public ActionResult SidebarPartial()
        {
            var userId = User.Identity.GetUserId();
            var projects = _context.Projects.Where(x => x.UserId == userId);
            var tags = _context.Tags.Where(x => x.UserId == userId);

            var colorss = new List<SelectListItem>
            {
                new SelectListItem {Text = "BLUE", Value = "BLUE"},
                new SelectListItem {Text = "AQUA", Value = "AQUA"},
                new SelectListItem {Text = "TEAL", Value = "TEAL"},
                new SelectListItem {Text = "OLIVE", Value = "OLIVE"},
                new SelectListItem {Text = "GREEN", Value = "GREEN"},
                new SelectListItem {Text = "LIME", Value = "LIME"},
                new SelectListItem {Text = "YELLOW", Value = "YELLOW"},
                new SelectListItem {Text = "ORANGE", Value = "ORANGE"},
                new SelectListItem {Text = "RED", Value = "RED"},
                new SelectListItem {Text = "MAROON", Value = "MAROON"},
                new SelectListItem {Text = "FUCHSIA", Value = "FUCHSIA"},
                new SelectListItem {Text = "PURPLE", Value = "PURPLE"},
                new SelectListItem {Text = "BLACK", Value = "BLACK"},
                new SelectListItem {Text = "GRAY", Value = "GRAY"},
                new SelectListItem {Text = "SILVER", Value = "SILVER"}
            };

            IEnumerable<SelectListItem> colors = colorss;

            var viewModel = new SidebarViewModel
            {
                Projects = projects,
                Tags = tags,
                ColorType = colors
            };

            return PartialView(viewModel);
        }

        [ChildActionOnly]
        public ActionResult AddTaskPartial()
        {
            var model = new Tasks();
            return PartialView(model);
        }
    }
}