using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineForum.Migrations
{
    public partial class AddNotificationReadAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReadAt",
                table: "Notifications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "37c5a2b8-e230-49df-8afe-97e547378065");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "LastSeen" },
                values: new object[] { "8c042903-a88c-4b58-9a53-738d11a7873d", new DateTime(2021, 2, 5, 20, 17, 42, 586, DateTimeKind.Local).AddTicks(1374), new DateTime(2021, 2, 5, 20, 17, 42, 584, DateTimeKind.Local).AddTicks(4260) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadAt",
                table: "Notifications");

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
        }
    }
}
