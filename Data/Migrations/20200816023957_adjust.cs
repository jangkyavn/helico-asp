using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class adjust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropColumn(
                name: "Description_EN",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Description_VN",
                table: "Projects");

            migrationBuilder.AddColumn<bool>(
                name: "IsHighlight",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SelectedAsSlider",
                table: "Projects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHighlight",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "SelectedAsSlider",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "Description_EN",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_VN",
                table: "Projects",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Description_EN = table.Column<string>(nullable: true),
                    Description_VN = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Position = table.Column<int>(nullable: true),
                    Status = table.Column<bool>(nullable: true),
                    Title_EN = table.Column<string>(nullable: true),
                    Title_VN = table.Column<string>(nullable: true),
                    Url_EN = table.Column<string>(nullable: true),
                    Url_VN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                });
        }
    }
}
