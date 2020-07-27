using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ProjectTranslationConfiguration : IEntityTypeConfiguration<ProjectTranslation>
    {
        public void Configure(EntityTypeBuilder<ProjectTranslation> builder)
        {
            builder.HasOne(n => n.Project)
             .WithMany(k => k.ProjectTranslations)
             .HasForeignKey(n => n.ProjectId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(n => n.Language)
                .WithMany(k => k.ProjectTranslations)
                .HasForeignKey(n => n.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
