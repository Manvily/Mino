using Mino.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Mino.Persistence.EntityConfigurations
{
    public class TasksConfiguration : EntityTypeConfiguration<Tasks>
    {
        public TasksConfiguration()
        {
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(t => t.UserId)
                .IsRequired();
        }
    }
}