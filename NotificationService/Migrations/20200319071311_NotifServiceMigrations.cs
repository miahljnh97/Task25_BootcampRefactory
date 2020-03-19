using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NotificationService.Migrations
{
    public partial class NotifServiceMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notification",
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
                    table.PrimaryKey("PK_notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "notificationLogs",
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
                    table.PrimaryKey("PK_notificationLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notificationLogs_notification_Notification_id",
                        column: x => x.Notification_id,
                        principalTable: "notification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_notificationLogs_Notification_id",
                table: "notificationLogs",
                column: "Notification_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notificationLogs");

            migrationBuilder.DropTable(
                name: "notification");
        }
    }
}
