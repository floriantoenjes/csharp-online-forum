using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineForum.Migrations
{
    public partial class CreateNotifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotificationType = table.Column<int>(type: "int", nullable: false),
                    TypeIdentifier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "b2f82e11-361a-4d33-82fa-8d5832215033");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "LastSeen" },
                values: new object[] { "d376e797-f58d-45e2-8d41-b9f9a3a85681", new DateTime(2021, 1, 24, 22, 3, 47, 797, DateTimeKind.Local).AddTicks(7184), new DateTime(2021, 1, 24, 22, 3, 47, 796, DateTimeKind.Local).AddTicks(506) });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_ReceiverId",
                table: "Notification",
                column: "ReceiverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "31b7eeb2-ccb4-4bee-a35f-a2e16d047d18");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "LastSeen" },
                values: new object[] { "e2c9cbfd-4e67-4ec9-b9a7-ae67d58bb9c7", new DateTime(2021, 1, 24, 11, 6, 9, 143, DateTimeKind.Local).AddTicks(9803), new DateTime(2021, 1, 24, 11, 6, 9, 141, DateTimeKind.Local).AddTicks(9630) });
        }
    }
}
