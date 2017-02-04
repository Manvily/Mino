using Microsoft.AspNet.Identity;
using Mino.Models;
using System.Linq;
using System.Web.Mvc;

namespace Mino.Controllers
{
    public class TagsController : Controller
    {
        private ApplicationDbContext _context;

        public TagsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Show()
        {
            var userId = User.Identity.GetUserId();
            var tags = _context.Tags.Where(x =>
                x.UserId == userId)
                .ToList();

            return View(tags);
        }
    }
}