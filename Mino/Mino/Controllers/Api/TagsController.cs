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
