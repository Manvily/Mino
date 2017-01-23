using Microsoft.AspNet.Identity;
using Mino.Dtos;
using Mino.Models;
using System.Web.Http;

namespace Mino.Controllers.Api
{
    [Authorize]
    public class TasksController : ApiController
    {
        private ApplicationDbContext _context;

        public TasksController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Add(UserTaskDto dto)
        {
            var userTask = new Tasks
            {
                Name = dto.Name,
                UserId = User.Identity.GetUserId()
            };

            _context.Tasks.Add(userTask);
            _context.SaveChanges();

            return Ok();
        }
    }
}
