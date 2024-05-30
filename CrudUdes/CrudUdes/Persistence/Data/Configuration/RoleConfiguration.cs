using CrudUdes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudUdes.Persistence.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles");
            builder.Property(x => x.RoleName)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(x => x.RoleDescription)
                   .HasMaxLength(300);

        }
    }
}
