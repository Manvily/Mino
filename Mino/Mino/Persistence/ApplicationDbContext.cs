using Microsoft.AspNet.Identity.EntityFramework;
using Mino.Core.Models;
using Mino.Persistence.EntityConfigurations;
using System.Data.Entity;

namespace Mino.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new TasksConfiguration());

            modelBuilder.Configurations.Add(new ProjectConfiguration());

            modelBuilder.Configurations.Add(new TagConfiguration());
        }
    }
}