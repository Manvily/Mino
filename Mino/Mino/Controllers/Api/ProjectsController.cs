using Microsoft.AspNet.Identity;
using Mino.Dtos;
using Mino.Models;
using System.Linq;
using System.Web.Http;

namespace Mino.Controllers.Api
{
    [Authorize]
    public class ProjectsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProjectsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Create(ProjectDto dto)
        {
            var project = new Project
            {
                Name = dto.Name,
                Color = dto.Color,
                UserId = User.Identity.GetUserId()
            };

            _context.Projects.Add(project);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(ProjectDto dto)
        {
            var userId = User.Identity.GetUserId();
            var project = _context.Projects.Single(x =>
            x.Id == dto.Id &&
            x.UserId == userId);

            _context.Projects.Remove(project);
            _context.SaveChanges();

            return Ok();
        }
    }
}
