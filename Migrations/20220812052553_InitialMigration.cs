using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskModsen.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventFeasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameOfEvent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesctiptionOfEvent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FioOrganizator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FioSpeaker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeOfEvent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventFeasts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventFeasts");
        }
    }
}
