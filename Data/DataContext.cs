using Data.Configurations;
using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    public class DataContext : IdentityDbContext<User, Role, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DataContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Entities.Action> Actions { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Diary> Diaries { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<Slide> Slides { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new PermissionConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductImageConfiguration());
            builder.ApplyConfiguration(new ProjectConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }

        public override int SaveChanges()
        {
            UpdateAuditEntities();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateAuditEntities();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateAuditEntities();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditEntities();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateAuditEntities()
        {
            IEnumerable<EntityEntry> entities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added ||
                                                                                    x.State == EntityState.Modified);

            string nameIdentifier = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid? currentUserId = null;
            if (!string.IsNullOrEmpty(nameIdentifier))
            {
                currentUserId = new Guid(nameIdentifier);
            }

            foreach (EntityEntry item in entities)
            {
                IAuditableEntity changedOrAddedItem = item.Entity as IAuditableEntity;
                DateTime now = DateTime.Now;

                if (changedOrAddedItem != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        if (changedOrAddedItem.CreatedBy == null && currentUserId != null)
                        {
                            changedOrAddedItem.CreatedBy = currentUserId;
                        }

                        changedOrAddedItem.CreatedDate = now;
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        if (changedOrAddedItem.ModifiedBy == null && currentUserId != null)
                        {
                            changedOrAddedItem.ModifiedBy = currentUserId;
                        }

                        changedOrAddedItem.ModifiedDate = now;
                    }
                    else if (item.State == EntityState.Deleted)
                    {
                        ///
                    }
                }
            }
        }
    }
}
