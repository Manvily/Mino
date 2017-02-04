using Microsoft.AspNet.Identity;
using Mino.Dtos;
using Mino.Models;
using System.Linq;
using System.Web.Http;

namespace Mino.Controllers.Api
{
    [Authorize]
    public class TagsController : ApiController
    {
        private ApplicationDbContext _context;

        public TagsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Create(TagDto dto)
        {
            var tag = new Tag
            {
                Name = dto.Name,
                UserId = User.Identity.GetUserId()
            };

            _context.Tags.Add(tag);
            _context.SaveChanges();

            return Ok();
        }

        public IHttpActionResult Delete(TagDto dto)
        {
            var userId = User.Identity.GetUserId();
            var tag = _context.Tags.Single(x =>
            x.UserId == userId &&
            x.Id == dto.Id);

            _context.Tags.Remove(tag);
            _context.SaveChanges();

            return Ok();
        }
    }
}
