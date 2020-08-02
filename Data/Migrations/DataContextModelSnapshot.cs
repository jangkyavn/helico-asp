﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entities.AboutUs", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<bool?>("Status");

                    b.HasKey("Id");

                    b.ToTable("AboutUs");
                });

            modelBuilder.Entity("Data.Entities.AboutUsTranslation", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AboutUsId");

                    b.Property<string>("Content");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("LanguageId");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("SeoAlias");

                    b.Property<string>("SeoDescription");

                    b.Property<string>("SeoKeywords");

                    b.Property<string>("SeoPageTitle");

                    b.Property<bool?>("Status");

                    b.HasKey("Id");

                    b.HasIndex("AboutUsId");

                    b.HasIndex("LanguageId");

                    b.ToTable("AboutUsTranslations");
                });

            modelBuilder.Entity("Data.Entities.Action", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<int?>("Position");

                    b.Property<bool?>("Status");

                    b.HasKey("Id");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("Data.Entities.Contact", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Content");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<string>("Location");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Phone");

                    b.Property<bool?>("Status");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Data.Entities.Diary", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<string>("Browser");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("Device");

                    b.Property<string>("IPAddress");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Diaries");
                });

            modelBuilder.Entity("Data.Entities.Function", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Icon");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<string>("Path");

                    b.Property<int?>("Position");

                    b.Property<bool?>("Status");

                    b.HasKey("Id");

                    b.ToTable("Functions");
                });

            modelBuilder.Entity("Data.Entities.Language", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Image");

                    b.Property<bool>("IsDefault");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<bool?>("Status");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Data.Entities.Notification", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("ObjectId");

                    b.Property<bool?>("Read");

                    b.Property<string>("ReceiverId");

                    b.Property<string>("SenderId");

                    b.Property<bool?>("Status");

                    b.Property<int>("Type");

                    b.Property<bool?>("View");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Data.Entities.Permission", b =>
                {
                    b.Property<string>("RoleId");

                    b.Property<string>("FunctionId");

                    b.Property<string>("ActionId");

                    b.HasKey("RoleId", "FunctionId", "ActionId");

                    b.HasIndex("ActionId");

                    b.HasIndex("FunctionId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Data.Entities.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryId");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Image");

                    b.Property<bool?>("IsTypical");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<decimal?>("Price");

                    b.Property<int?>("Quantity");

                    b.Property<bool?>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Data.Entities.ProductCategory", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int?>("Position");

                    b.Property<bool?>("Status");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Data.Entities.ProductCategoryTranslation", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("LanguageId");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<string>("ProductCategoryId");

                    b.Property<string>("SeoAlias");

                    b.Property<string>("SeoDescription");

                    b.Property<string>("SeoKeywords");

                    b.Property<string>("SeoPageTitle");

                    b.Property<bool?>("Status");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("ProductCategoryTranslations");
                });

            modelBuilder.Entity("Data.Entities.ProductImage", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Image");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<string>("ProductId");

                    b.Property<bool?>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("Data.Entities.ProductTranslation", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("DetailedDescription");

                    b.Property<string>("LanguageId");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<string>("ProductId");

                    b.Property<string>("SeoAlias");

                    b.Property<string>("SeoDescription");

                    b.Property<string>("SeoKeywords");

                    b.Property<string>("SeoPageTitle");

                    b.Property<string>("ShortDescription");

                    b.Property<bool?>("Status");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductTranslations");
                });

            modelBuilder.Entity("Data.Entities.Project", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryId");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Image");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("ProjectCategoryId");

                    b.Property<bool?>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ProjectCategoryId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Data.Entities.ProjectCategory", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int?>("Position");

                    b.Property<bool?>("Status");

                    b.HasKey("Id");

                    b.ToTable("ProjectCategories");
                });

            modelBuilder.Entity("Data.Entities.ProjectCategoryTranslation", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("LanguageId");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<string>("ProjectCategoryId");

                    b.Property<string>("SeoAlias");

                    b.Property<string>("SeoDescription");

                    b.Property<string>("SeoKeywords");

                    b.Property<string>("SeoPageTitle");

                    b.Property<bool?>("Status");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ProjectCategoryId");

                    b.ToTable("ProjectCategoryTranslations");
                });

            modelBuilder.Entity("Data.Entities.ProjectTranslation", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("LanguageId");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<string>("ProjectId");

                    b.Property<string>("SeoAlias");

                    b.Property<string>("SeoDescription");

                    b.Property<string>("SeoKeywords");

                    b.Property<string>("SeoPageTitle");

                    b.Property<bool?>("Status");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectTranslations");
                });

            modelBuilder.Entity("Data.Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<int?>("Position");

                    b.Property<bool?>("Status");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Data.Entities.Slide", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Image");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int?>("Position");

                    b.Property<bool?>("Status");

                    b.HasKey("Id");

                    b.ToTable("Slides");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Avatar");

                    b.Property<DateTime?>("BirthDay");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Configuration");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<int>("Gender");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool?>("Status");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Data.Entities.AboutUsTranslation", b =>
                {
                    b.HasOne("Data.Entities.AboutUs", "AboutUs")
                        .WithMany("AboutUsTranslations")
                        .HasForeignKey("AboutUsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.Language", "Language")
                        .WithMany("AboutUsTranslations")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entities.Permission", b =>
                {
                    b.HasOne("Data.Entities.Action", "Action")
                        .WithMany("Permissions")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.Function", "Function")
                        .WithMany("Permissions")
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entities.Product", b =>
                {
                    b.HasOne("Data.Entities.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Data.Entities.ProductCategoryTranslation", b =>
                {
                    b.HasOne("Data.Entities.Language", "Language")
                        .WithMany("ProductCategoryTranslations")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.ProductCategory", "ProductCategory")
                        .WithMany("ProductCategoryTranslations")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entities.ProductImage", b =>
                {
                    b.HasOne("Data.Entities.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entities.ProductTranslation", b =>
                {
                    b.HasOne("Data.Entities.Language", "Language")
                        .WithMany("ProductTranslations")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.Product", "Product")
                        .WithMany("ProductTranslations")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entities.Project", b =>
                {
                    b.HasOne("Data.Entities.ProjectCategory", "ProjectCategory")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectCategoryId");
                });

            modelBuilder.Entity("Data.Entities.ProjectCategoryTranslation", b =>
                {
                    b.HasOne("Data.Entities.Language", "Language")
                        .WithMany("ProjectCategoryTranslations")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.ProjectCategory", "ProjectCategory")
                        .WithMany("ProjectCategoryTranslations")
                        .HasForeignKey("ProjectCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entities.ProjectTranslation", b =>
                {
                    b.HasOne("Data.Entities.Language", "Language")
                        .WithMany("ProjectTranslations")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.Project", "Project")
                        .WithMany("ProjectTranslations")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Data.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Data.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
