using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ProductCategoryTranslationConfiguration : IEntityTypeConfiguration<ProductCategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryTranslation> builder)
        {
            builder.HasOne(n => n.ProductCategory)
             .WithMany(k => k.ProductCategoryTranslations)
             .HasForeignKey(n => n.ProductCategoryId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(n => n.Language)
                .WithMany(k => k.ProductCategoryTranslations)
                .HasForeignKey(n => n.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
