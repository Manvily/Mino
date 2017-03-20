using Mino.Core;
using Mino.Core.Repositories;
using Mino.Persistence.Repositories;

namespace Mino.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ITaskRepository Tasks { get; private set; }
        public ITagRepository Tags { get; private set; }
        public IProjectRepository Projects { get; private set; }
        public INotificationRepository Notifications { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Tasks = new TaskRepository(context);
            Tags = new TagRepository(context);
            Projects = new ProjectRepository(context);
            Notifications = new NotificationRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}