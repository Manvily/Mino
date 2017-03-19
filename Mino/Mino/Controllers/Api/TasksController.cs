using Microsoft.AspNet.Identity;
using Mino.Core;
using Mino.Core.Dtos;
using Mino.Core.Models;
using System.Web.Http;

namespace Mino.Controllers.Api
{
    [Authorize]
    public class TasksController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public TasksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Create(TaskDto dto)
        {
            var task = new Tasks
            {
                Name = dto.Name,
                UserId = User.Identity.GetUserId()
            };

            _unitOfWork.Tasks.Add(task);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Edit(TaskDto dto)
        {
            var task =
                _unitOfWork.Tasks
                .GetTask(User.Identity.GetUserId(), dto.TaskId);

            task.Modify(dto.Name,
                dto.Priority,
                dto.ProjectId,
                dto.TagId,
                dto.GetDateTime());

            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(TaskDto dto)
        {
            var task =
                _unitOfWork.Tasks
                .GetTask(User.Identity.GetUserId(), dto.TaskId);

            _unitOfWork.Tasks.Remove(task);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Finish(TaskDto dto)
        {
            var task =
                _unitOfWork.Tasks
                .GetTask(User.Identity.GetUserId(), dto.TaskId);

            task.Finish();
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
