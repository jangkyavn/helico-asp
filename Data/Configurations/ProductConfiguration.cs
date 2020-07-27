using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(n => n.ProductCategory)
             .WithMany(k => k.Products)
             .HasForeignKey(n => n.CategoryId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
