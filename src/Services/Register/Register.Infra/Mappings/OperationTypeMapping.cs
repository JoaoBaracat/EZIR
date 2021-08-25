using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Register.Domain.Entities;

namespace Register.Infra.Mappings
{
    public class OperationTypeMapping : IEntityTypeConfiguration<OperationType>
    {
        public void Configure(EntityTypeBuilder<OperationType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).IsRequired()
                .HasMaxLength(50)
                .HasColumnType("VARCHAR(50)");
        }
    }
}