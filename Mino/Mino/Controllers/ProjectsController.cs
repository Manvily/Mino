using Microsoft.AspNet.Identity;
using Mino.Persistence;
using System.Web.Mvc;
using Mino.Core.Models;
using Mino.Core.ViewModels;

namespace Mino.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly UnitOfWork _unitOfWork;


        public ProjectsController()
        {
            var context = new ApplicationDbContext();
            _unitOfWork = new UnitOfWork(context);

        }

        public ActionResult Show()
        {
            var viewModel =
                new ProjectsViewModel(_unitOfWork.Projects
                .GetUserProjects(User.Identity.GetUserId()));

            return View(viewModel);
        }

    }
}