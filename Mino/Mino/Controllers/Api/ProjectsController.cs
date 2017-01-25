using Microsoft.AspNet.Identity;
using Mino.Dtos;
using Mino.Models;
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
    }
}
