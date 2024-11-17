using Ambev.DeveloperEvaluation.Domain.Constants;
using Ambev.DeveloperEvaluation.Domain.Entities.Sale;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping.SaleConfiguration
{
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable("SalesItems");

            builder.HasKey(si => si.Id);
            builder.Property(si => si.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(si => si.SaleId).IsRequired();
            builder.Property(si => si.ProductId).IsRequired();
            builder.Property(si => si.ProductName).IsRequired().HasMaxLength(Constants.ProductNameMaxLength);
            builder.Property(si => si.UnitPrice).IsRequired().HasPrecision(18, 2);
            builder.Property(si => si.Quantity).IsRequired();
            builder.Property(si => si.Discount).IsRequired().HasPrecision(3, 2);
            builder.Property(si => si.TotalAmount).IsRequired().HasPrecision(18, 2);
            builder.Property(si => si.IsCancelled).IsRequired();
        }
    }
}
