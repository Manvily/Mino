using Microsoft.AspNet.Identity;
using Mino.Core;
using Mino.Core.ViewModels;
using System.Web.Mvc;

namespace Mino.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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