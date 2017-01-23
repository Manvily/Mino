using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Mino.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}