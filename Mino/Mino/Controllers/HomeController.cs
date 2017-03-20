using Microsoft.AspNet.Identity;
using Mino.Core;
using Mino.Core.ViewModels;
using Mino.Persistence.ControllerHelper;
using System.Web.Mvc;

namespace Mino.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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