using Microsoft.AspNet.Identity;
using Mino.Persistence;
using System.Web.Mvc;
using Mino.Core.Models;
using Mino.Core.ViewModels;

namespace Mino.Controllers
{
    public class TagsController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public TagsController()
        {
            var context = new ApplicationDbContext();
            _unitOfWork = new UnitOfWork(context);
        }

        public ActionResult Show()
        {
            var viewModel =
                new TagsViewModel(_unitOfWork.Tags
                .GetUserTags(User.Identity.GetUserId()));

            return View(viewModel);
        }


    }
}