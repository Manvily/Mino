using Microsoft.AspNet.Identity;
using Mino.Persistence;
using System.Web.Http;
using Mino.Core.Dtos;
using Mino.Core.Models;

namespace Mino.Controllers.Api
{
    [Authorize]
    public class TagsController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;

        public TagsController()
        {
            var context = new ApplicationDbContext();
            _unitOfWork = new UnitOfWork(context);
        }

        [HttpPost]
        public IHttpActionResult Create(TagDto dto)
        {
            var tag = new Tag
            {
                Name = dto.Name,
                UserId = User.Identity.GetUserId()
            };

            _unitOfWork.Tags.Add(tag);
            _unitOfWork.Complete();

            return Ok();
        }

        //todo be carefoul HTTPDELETE
        public IHttpActionResult Delete(TagDto dto)
        {
            var tag =
                _unitOfWork.Tags
                .GetUserTag(User.Identity.GetUserId(), dto.Id);

            _unitOfWork.Tags.Remove(tag);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
