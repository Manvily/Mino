﻿using Microsoft.AspNet.Identity;
using Mino.Models;
using Mino.ViewModels;
using System;
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

            return View(tasks);
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
                        x.DateTime > today &&
                        x.DateTime < tomorrow)
                        .Include(p => p.Project)
                        .Include(t => t.Tag)
                        .ToList();

            return View("index", tasks);
        }

        public ActionResult Project(int projectId)
        {
            var userId = User.Identity.GetUserId();
            var tasks = _context.Tasks
                .Where(x => x.UserId == userId &&
                !x.IsDone &&
                x.ProjectId == projectId)
                    .Include(p => p.Project)
                    .Include(t => t.Tag)
                    .ToList();

            return View("Index", tasks);
        }

        public ActionResult Tag(int tagId)
        {
            var userId = User.Identity.GetUserId();
            var tasks = _context.Tasks
                .Where(x => x.UserId == userId &&
                            !x.IsDone &&
                            x.TagId == tagId)
                            .Include(p => p.Project)
                            .Include(t => t.Tag)
                            .ToList();

            return View("Index", tasks);
        }

        [ChildActionOnly]
        public ActionResult SidebarPartial()
        {
            var userId = User.Identity.GetUserId();
            var projects = _context.Projects.Where(x => x.UserId == userId);
            var tags = _context.Tags.Where(x => x.UserId == userId);

            var viewModel = new SidebarViewModel
            {
                Projects = projects,
                Tags = tags
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