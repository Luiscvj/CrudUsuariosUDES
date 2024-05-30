using CrudUdes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudUdes.Persistence.Data.Configuration
{
    public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.ToTable("document_type");
            builder.Property(x => x.type)
                   .HasMaxLength(40)
                   .IsRequired();

        }
    }
}
