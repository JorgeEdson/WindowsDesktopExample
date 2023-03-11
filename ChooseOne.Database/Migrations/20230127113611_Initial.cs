using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChooseOne.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ChooseComponent = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    BackGroundColor = table.Column<string>(nullable: true),
                    ForeGroundColor = table.Column<string>(nullable: true),
                    CornerRadius = table.Column<string>(nullable: true),
                    MaxValue = table.Column<string>(nullable: true),
                    MinValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customizations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customizations");
        }
    }
}
