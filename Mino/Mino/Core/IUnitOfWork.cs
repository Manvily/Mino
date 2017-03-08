using Mino.Core.Repositories;

namespace Mino.Core
{
    public interface IUnitOfWork
    {
        ITaskRepository Tasks { get; }
        ITagRepository Tags { get; }
        IProjectRepository Projects { get; }
        INotificationRepository Notifications { get; }
        void Complete();
    }
}