using Microsoft.AspNet.Identity;
using Mino.Models;
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
            var tasks = _context.Tasks
                .Where(x => x.UserId == userId && !x.IsDone && x.ProjectId == null)
                .Include(p => p.Project)
                .Include(t => t.Tag).ToList();

            return View(tasks);
        }

        [ChildActionOnly]
        public ActionResult AddPartial()
        {
            var model = new Tasks();
            return PartialView(model);
        }
    }
}