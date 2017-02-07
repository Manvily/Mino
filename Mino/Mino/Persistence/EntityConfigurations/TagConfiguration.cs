using Mino.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Mino.Persistence.EntityConfigurations
{
    public class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            Property(t => t.UserId)
                .IsRequired();

            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}