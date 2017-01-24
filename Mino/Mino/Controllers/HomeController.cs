using System.Web.Mvc;

namespace Mino.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Tasks");
            }

            return View();
        }
    }
}