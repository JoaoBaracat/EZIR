using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Register.Domain.Entities;

namespace Register.Infra.Mappings
{
    public class UserConfigurationMapping : IEntityTypeConfiguration<UserConfiguration>
    {
        public void Configure(EntityTypeBuilder<UserConfiguration> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired()
                .HasMaxLength(50)
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Email).IsRequired()
                .HasMaxLength(100)
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.InitialBalance).IsRequired();
        }
    }
}