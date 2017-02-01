using Microsoft.AspNet.Identity;
using Mino.Dtos;
using Mino.Models;
using System.Linq;
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

        [HttpPut]
        public IHttpActionResult Create(TaskDto dto)
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

        [HttpPost]
        public IHttpActionResult Edit(TaskDto dto)
        {
            var userId = User.Identity.GetUserId();
            var task = _context.Tasks.Single(g =>
            g.Id == dto.TaskId &&
            g.UserId == userId);

            task.Modify(dto.Name, dto.Priority, dto.ProjectId, dto.TagId, dto.GetDateTime());

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(TaskDto dto)
        {
            var userId = User.Identity.GetUserId();
            var task = _context.Tasks.Single(a =>
            a.UserId == userId &&
            a.Id == dto.TaskId);

            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return Ok();
        }
    }
}
