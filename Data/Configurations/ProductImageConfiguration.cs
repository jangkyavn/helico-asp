using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasOne(n => n.Product)
             .WithMany(k => k.ProductImages)
             .HasForeignKey(n => n.ProductId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
