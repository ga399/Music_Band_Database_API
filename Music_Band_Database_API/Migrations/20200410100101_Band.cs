using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Music_Band_Database_API.Migrations
{
    public partial class Band : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BandDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Band_Name = table.Column<string>(nullable: true),
                    Producer_Name = table.Column<string>(nullable: true),
                    Album_Name = table.Column<string>(nullable: true),
                    Album_ReleaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandDetails", x => x.Id);
                });
            var sqlFile = Path.Combine(".\\DatabaseScript", @"DataQueries.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BandDetails");
        }
    }
}
