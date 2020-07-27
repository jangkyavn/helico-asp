using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(x => new { x.RoleId, x.FunctionId, x.ActionId });

            builder.HasOne(n => n.Role)
             .WithMany(k => k.Permissions)
             .HasForeignKey(n => n.RoleId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(n => n.Function)
                .WithMany(k => k.Permissions)
                .HasForeignKey(n => n.FunctionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(n => n.Action)
                .WithMany(k => k.Permissions)
                .HasForeignKey(n => n.ActionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
