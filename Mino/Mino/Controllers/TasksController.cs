using Microsoft.AspNet.Identity;
using Mino.Core;
using Mino.Core.Models;
using Mino.Core.ViewModels;
using Mino.Persistence.ControllerHelper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Mino.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TasksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index(string query = null)
        {
            IEnumerable<Tasks> tasks;
            if (String.IsNullOrEmpty(query))
            {
                tasks = _unitOfWork.Tasks
                    .GetUserTasksByProject(User.Identity.GetUserId(), null);
            }
            else
            {
                ViewBag.IsSearch = "true";
                tasks = _unitOfWork.Tasks.SearchTasks(User.Identity.GetUserId(), query);
            }

            var viewModel =
                    new TasksViewModel(tasks);

            return View("Index", viewModel);
        }

        public ActionResult Today()
        {
            var viewModel =
                new TasksViewModel(_unitOfWork.Tasks
                .GetTodayTasks(User.Identity.GetUserId()), "Today");

            return View("Index", viewModel);
        }

        public ActionResult NextWeek()
        {
            var viewModel =
                new WeeklyTasksViewModel(
                    new NextWeek(_unitOfWork.Tasks
                    .GetNextWeekTasks(User.Identity.GetUserId()))
                    .GetWeekTasks());

            return View(viewModel);
        }

        public ActionResult Project(int projectId)
        {
            var viewModel =
                new TasksViewModel(_unitOfWork.Tasks
                .GetUserTasksByProject(User.Identity.GetUserId(), projectId));

            return View("Index", viewModel);
        }

        public ActionResult Tag(int tagId)
        {
            var viewModel =
                new TasksViewModel(_unitOfWork.Tasks
                .GetUserTasksByTag(User.Identity.GetUserId(), tagId));

            return View("Index", viewModel);
        }

        [HttpPost]
        public ActionResult Search(SidebarViewModel viewModel)
        {
            return RedirectToAction("Index", "Tasks", new { query = viewModel.SearchTerm });
        }

        [ChildActionOnly]
        public ActionResult Overdue()
        {
            var viewModel =
                new TasksViewModel(_unitOfWork.Tasks
                .GetOverdueTasks(User.Identity.GetUserId()));

            foreach (var task in viewModel.Tasks)
            {
                viewModel.TitleName = "Overdue";
                break;
            }

            return PartialView("Index", viewModel);
        }

        [ChildActionOnly]
        public ActionResult AddTaskPartial()
        {
            return PartialView(new Tasks());
        }
    }
}