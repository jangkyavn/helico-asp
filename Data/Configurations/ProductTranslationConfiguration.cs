using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ProductTranslationConfiguration : IEntityTypeConfiguration<ProductTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductTranslation> builder)
        {
            builder.HasOne(n => n.Product)
             .WithMany(k => k.ProductTranslations)
             .HasForeignKey(n => n.ProductId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(n => n.Language)
                .WithMany(k => k.ProductTranslations)
                .HasForeignKey(n => n.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
