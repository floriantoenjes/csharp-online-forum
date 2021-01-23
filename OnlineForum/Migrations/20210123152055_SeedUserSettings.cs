using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineForum.Migrations
{
    public partial class SeedUserSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "JoinedAt", "LastSeen" },
                values: new object[] { new DateTime(2021, 1, 23, 16, 20, 55, 199, DateTimeKind.Local).AddTicks(9477), new DateTime(2021, 1, 23, 16, 20, 55, 198, DateTimeKind.Local).AddTicks(2994) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "JoinedAt", "LastSeen" },
                values: new object[] { new DateTime(2021, 1, 23, 13, 55, 20, 609, DateTimeKind.Local).AddTicks(8514), new DateTime(2021, 1, 23, 13, 55, 20, 608, DateTimeKind.Local).AddTicks(2857) });
        }
    }
}
