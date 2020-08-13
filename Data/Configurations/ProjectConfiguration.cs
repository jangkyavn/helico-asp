using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasOne(n => n.ProjectCategory)
             .WithMany(k => k.Projects)
             .HasForeignKey(n => n.CategoryId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
