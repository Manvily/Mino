using Microsoft.AspNet.Identity;
using Mino.Core;
using Mino.Core.Dtos;
using Mino.Core.Models;
using System.Web.Http;

namespace Mino.Controllers.Api
{
    [Authorize]
    public class ProjectsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

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

            _unitOfWork.Projects.Add(project);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(ProjectDto dto)
        {
            var userId = User.Identity.GetUserId();
            var project = _unitOfWork.Projects.GetUserProject(userId, dto.Id);

            _unitOfWork.Projects.Remove(project);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
