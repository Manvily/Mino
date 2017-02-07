using Mino.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Mino.Persistence.EntityConfigurations
{
    public class ProjectConfiguration : EntityTypeConfiguration<Project>
    {
        public ProjectConfiguration()
        {
            Property(p => p.Color)
                .IsRequired();

            Property(p => p.UserId)
                .IsRequired();

            Property(p => p.Name)
                .IsRequired();
        }
    }
}