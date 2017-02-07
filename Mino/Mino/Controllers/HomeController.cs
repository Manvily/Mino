using Microsoft.AspNet.Identity;
using Mino.Core.ViewModels;
using Mino.Persistence;
using System.Web.Mvc;
using Mino.Persistence.ControllerHelper;

namespace Mino.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public HomeController()
        {
            var context = new ApplicationDbContext();
            _unitOfWork = new UnitOfWork(context);
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Tasks");

            return View();
        }

        [ChildActionOnly]
        public ActionResult SidebarPartial()
        {
            var userId = User.Identity.GetUserId();
            var viewModel = new SidebarViewModel
            {
                Projects = _unitOfWork.Projects.GetUserProjects(userId),
                Tags = _unitOfWork.Tags.GetUserTags(userId),
                ColorType = new ProjectColors().Colors
            };

            return PartialView(viewModel);
        }
    }
}