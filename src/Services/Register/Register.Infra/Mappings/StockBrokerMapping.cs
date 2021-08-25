using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Register.Domain.Entities;

namespace Register.Infra.Mappings
{
    public class StockBrokerMapping : IEntityTypeConfiguration<StockBroker>
    {
        public void Configure(EntityTypeBuilder<StockBroker> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.User).IsRequired();

            builder.Property(x => x.Name).IsRequired()
                .HasMaxLength(50)
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.FeeType).IsRequired();
            builder.Property(x => x.BrokerageValue).IsRequired();
        }
    }
}