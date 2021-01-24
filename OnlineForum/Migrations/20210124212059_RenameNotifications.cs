using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineForum.Migrations
{
    public partial class RenameNotifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_AspNetUsers_ReceiverId",
                table: "Notification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notification",
                table: "Notification");

            migrationBuilder.RenameTable(
                name: "Notification",
                newName: "Notifications");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_ReceiverId",
                table: "Notifications",
                newName: "IX_Notifications_ReceiverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0532c1cb-8f62-40d7-bb83-81ccd4b2090a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "LastSeen" },
                values: new object[] { "ca4b9625-4a27-401c-939e-e3000635a91d", new DateTime(2021, 1, 24, 22, 20, 58, 832, DateTimeKind.Local).AddTicks(5049), new DateTime(2021, 1, 24, 22, 20, 58, 830, DateTimeKind.Local).AddTicks(8333) });

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_ReceiverId",
                table: "Notifications",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_ReceiverId",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "Notification");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_ReceiverId",
                table: "Notification",
                newName: "IX_Notification_ReceiverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notification",
                table: "Notification",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_AspNetUsers_ReceiverId",
                table: "Notification",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
