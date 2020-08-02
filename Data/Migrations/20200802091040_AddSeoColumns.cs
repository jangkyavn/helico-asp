using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddSeoColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Specification",
                table: "ProductTranslations",
                newName: "SeoPageTitle");

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "ProjectTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoDescription",
                table: "ProjectTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoKeywords",
                table: "ProjectTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoPageTitle",
                table: "ProjectTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "ProductTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoDescription",
                table: "ProductTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoKeywords",
                table: "ProductTranslations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "ProjectTranslations");

            migrationBuilder.DropColumn(
                name: "SeoDescription",
                table: "ProjectTranslations");

            migrationBuilder.DropColumn(
                name: "SeoKeywords",
                table: "ProjectTranslations");

            migrationBuilder.DropColumn(
                name: "SeoPageTitle",
                table: "ProjectTranslations");

            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "ProductTranslations");

            migrationBuilder.DropColumn(
                name: "SeoDescription",
                table: "ProductTranslations");

            migrationBuilder.DropColumn(
                name: "SeoKeywords",
                table: "ProductTranslations");

            migrationBuilder.RenameColumn(
                name: "SeoPageTitle",
                table: "ProductTranslations",
                newName: "Specification");
        }
    }
}
