using Microsoft.AspNet.Identity;
using Mino.Models;
using System.Linq;
using System.Web.Mvc;

namespace Mino.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationDbContext _context;

        public ProjectsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Show()
        {
            var userId = User.Identity.GetUserId();
            var projects = _context.Projects.Where(x =>
                x.UserId == userId)
                .ToList();

            return View(projects);
        }
    }
}