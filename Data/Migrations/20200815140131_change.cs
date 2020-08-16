using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectCategories_ProjectCategoryId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "AboutUsTranslations");

            migrationBuilder.DropTable(
                name: "ProductCategoryTranslations");

            migrationBuilder.DropTable(
                name: "ProductTranslations");

            migrationBuilder.DropTable(
                name: "ProjectCategoryTranslations");

            migrationBuilder.DropTable(
                name: "ProjectTranslations");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectCategoryId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ProjectCategoryId",
                table: "Projects",
                newName: "Name_VN");

            migrationBuilder.RenameColumn(
                name: "IsTypical",
                table: "Products",
                newName: "IsHighlight");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name_VN",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content_EN",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content_VN",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_EN",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_VN",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_EN",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_EN",
                table: "ProjectCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_VN",
                table: "ProjectCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailedDescription_EN",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailedDescription_VN",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_EN",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_VN",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription_EN",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription_VN",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_EN",
                table: "ProductCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_VN",
                table: "ProductCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content_EN",
                table: "AboutUs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content_VN",
                table: "AboutUs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CategoryId",
                table: "Projects",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectCategories_CategoryId",
                table: "Projects",
                column: "CategoryId",
                principalTable: "ProjectCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectCategories_CategoryId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CategoryId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Content_EN",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Content_VN",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Description_EN",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Description_VN",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Name_EN",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Name_EN",
                table: "ProjectCategories");

            migrationBuilder.DropColumn(
                name: "Name_VN",
                table: "ProjectCategories");

            migrationBuilder.DropColumn(
                name: "DetailedDescription_EN",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DetailedDescription_VN",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name_EN",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name_VN",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShortDescription_EN",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShortDescription_VN",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name_EN",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "Name_VN",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "Content_EN",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "Content_VN",
                table: "AboutUs");

            migrationBuilder.RenameColumn(
                name: "Name_VN",
                table: "Projects",
                newName: "ProjectCategoryId");

            migrationBuilder.RenameColumn(
                name: "IsHighlight",
                table: "Products",
                newName: "IsTypical");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectCategoryId",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AboutUsTranslations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AboutUsId = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    LanguageId = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    SeoAlias = table.Column<string>(nullable: true),
                    SeoDescription = table.Column<string>(nullable: true),
                    SeoKeywords = table.Column<string>(nullable: true),
                    SeoPageTitle = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUsTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutUsTranslations_AboutUs_AboutUsId",
                        column: x => x.AboutUsId,
                        principalTable: "AboutUs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AboutUsTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategoryTranslations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    LanguageId = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProductCategoryId = table.Column<string>(nullable: true),
                    SeoAlias = table.Column<string>(nullable: true),
                    SeoDescription = table.Column<string>(nullable: true),
                    SeoKeywords = table.Column<string>(nullable: true),
                    SeoPageTitle = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategoryTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategoryTranslations_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTranslations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    DetailedDescription = table.Column<string>(nullable: true),
                    LanguageId = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true),
                    SeoAlias = table.Column<string>(nullable: true),
                    SeoDescription = table.Column<string>(nullable: true),
                    SeoKeywords = table.Column<string>(nullable: true),
                    SeoPageTitle = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTranslations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCategoryTranslations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    LanguageId = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProjectCategoryId = table.Column<string>(nullable: true),
                    SeoAlias = table.Column<string>(nullable: true),
                    SeoDescription = table.Column<string>(nullable: true),
                    SeoKeywords = table.Column<string>(nullable: true),
                    SeoPageTitle = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCategoryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectCategoryTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectCategoryTranslations_ProjectCategories_ProjectCategoryId",
                        column: x => x.ProjectCategoryId,
                        principalTable: "ProjectCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTranslations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LanguageId = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProjectId = table.Column<string>(nullable: true),
                    SeoAlias = table.Column<string>(nullable: true),
                    SeoDescription = table.Column<string>(nullable: true),
                    SeoKeywords = table.Column<string>(nullable: true),
                    SeoPageTitle = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTranslations_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectCategoryId",
                table: "Projects",
                column: "ProjectCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutUsTranslations_AboutUsId",
                table: "AboutUsTranslations",
                column: "AboutUsId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutUsTranslations_LanguageId",
                table: "AboutUsTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryTranslations_LanguageId",
                table: "ProductCategoryTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryTranslations_ProductCategoryId",
                table: "ProductCategoryTranslations",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_LanguageId",
                table: "ProductTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_ProductId",
                table: "ProductTranslations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCategoryTranslations_LanguageId",
                table: "ProjectCategoryTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCategoryTranslations_ProjectCategoryId",
                table: "ProjectCategoryTranslations",
                column: "ProjectCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTranslations_LanguageId",
                table: "ProjectTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTranslations_ProjectId",
                table: "ProjectTranslations",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectCategories_ProjectCategoryId",
                table: "Projects",
                column: "ProjectCategoryId",
                principalTable: "ProjectCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
