using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class AboutUsTranslationConfiguration : IEntityTypeConfiguration<AboutUsTranslation>
    {
        public void Configure(EntityTypeBuilder<AboutUsTranslation> builder)
        {
            builder.HasOne(n => n.AboutUs)
             .WithMany(k => k.AboutUsTranslations)
             .HasForeignKey(n => n.AboutUsId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(n => n.Language)
                .WithMany(k => k.AboutUsTranslations)
                .HasForeignKey(n => n.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
