using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AdjustSlideTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description_EN",
                table: "Slides",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_VN",
                table: "Slides",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title_EN",
                table: "Slides",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title_VN",
                table: "Slides",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url_EN",
                table: "Slides",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url_VN",
                table: "Slides",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description_EN",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "Description_VN",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "Title_EN",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "Title_VN",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "Url_EN",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "Url_VN",
                table: "Slides");
        }
    }
}
