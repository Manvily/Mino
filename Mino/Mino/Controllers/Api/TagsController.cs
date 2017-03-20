using Microsoft.AspNet.Identity;
using Mino.Core;
using Mino.Core.Dtos;
using Mino.Core.Models;
using System.Web.Http;

namespace Mino.Controllers.Api
{
    [Authorize]
    public class TagsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        [HttpDelete]
        public IHttpActionResult Delete(TagDto dto)
        {
            var userId = User.Identity.GetUserId();

            var tag =
                _unitOfWork.Tags
                .GetUserTag(userId, dto.Id);

            var tagTasks = _unitOfWork.Tasks.GetUserTasksByTag(userId, tag.Id);

            foreach (var task in tagTasks)
                task.TagId = null;

            _unitOfWork.Tags.Remove(tag);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
