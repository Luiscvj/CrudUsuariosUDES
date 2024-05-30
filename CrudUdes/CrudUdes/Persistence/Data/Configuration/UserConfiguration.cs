using CrudUdes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudUdes.Persistence.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.Property(x => x.Name)
                   .HasMaxLength(150);
                   
            builder.Property(x => x.LastName)
                   .HasMaxLength(100);
                 
            builder.Property(x => x.DocumentNumber)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Email)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(x => x.UserName)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(x => x.DocumentType)
                   .WithMany(x => x.Users)
                   .HasForeignKey(x => x.DocumentTypeId);

            builder.HasMany(x => x.Roles)
                   .WithMany(x => x.Users)
                   .UsingEntity<UserRoles>();
        }
    }
    
}
