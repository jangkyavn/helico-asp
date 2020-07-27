using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ProjectCategoryTranslationConfiguration : IEntityTypeConfiguration<ProjectCategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<ProjectCategoryTranslation> builder)
        {
            builder.HasOne(n => n.ProjectCategory)
             .WithMany(k => k.ProjectCategoryTranslations)
             .HasForeignKey(n => n.ProjectCategoryId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(n => n.Language)
                .WithMany(k => k.ProjectCategoryTranslations)
                .HasForeignKey(n => n.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
