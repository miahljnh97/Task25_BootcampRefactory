using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RestService.Migrations
{
    public partial class RestServiceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notifs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Created_at = table.Column<DateTime>(nullable: false),
                    Update_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "notifLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Notification_id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    From = table.Column<int>(nullable: false),
                    Target = table.Column<int>(nullable: false),
                    Email_destination = table.Column<string>(nullable: true),
                    Read_at = table.Column<DateTime>(nullable: false),
                    Created_at = table.Column<DateTime>(nullable: false),
                    Update_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notifLogs_notifs_Notification_id",
                        column: x => x.Notification_id,
                        principalTable: "notifs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_notifLogs_Notification_id",
                table: "notifLogs",
                column: "Notification_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notifLogs");

            migrationBuilder.DropTable(
                name: "notifs");
        }
    }
}
