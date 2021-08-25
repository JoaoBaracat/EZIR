using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Register.Domain.Entities;

namespace Register.Infra.Mappings
{
    public class OperationMapping : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.User).IsRequired();
            builder.Property(x => x.OperationDate).IsRequired();
            builder.Property(x => x.OrderType).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();

            builder.Property(x => x.Ticker).IsRequired()
                .HasMaxLength(50)
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.CostsType).IsRequired();
            builder.Property(x => x.StockBroker).IsRequired();
            builder.Property(x => x.FeeType).IsRequired();
            builder.Property(x => x.OperationType).IsRequired();
        }
    }
}