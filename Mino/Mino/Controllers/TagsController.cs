using Microsoft.AspNet.Identity;
using Mino.Core;
using Mino.Core.ViewModels;
using System.Web.Mvc;

namespace Mino.Controllers
{
    public class TagsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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