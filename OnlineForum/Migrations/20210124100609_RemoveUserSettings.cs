using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineForum.Migrations
{
    public partial class RemoveUserSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThreadUserSettings");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.CreateTable(
                name: "ThreadUser",
                columns: table => new
                {
                    SubscribersId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThreadUser", x => new { x.SubscribersId, x.SubscriptionsId });
                    table.ForeignKey(
                        name: "FK_ThreadUser_AspNetUsers_SubscribersId",
                        column: x => x.SubscribersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThreadUser_Threads_SubscriptionsId",
                        column: x => x.SubscriptionsId,
                        principalTable: "Threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ThreadUser_SubscriptionsId",
                table: "ThreadUser",
                column: "SubscriptionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThreadUser");

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSettings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThreadUserSettings",
                columns: table => new
                {
                    SubscribersId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThreadUserSettings", x => new { x.SubscribersId, x.SubscriptionsId });
                    table.ForeignKey(
                        name: "FK_ThreadUserSettings_Threads_SubscriptionsId",
                        column: x => x.SubscriptionsId,
                        principalTable: "Threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThreadUserSettings_UserSettings_SubscribersId",
                        column: x => x.SubscribersId,
                        principalTable: "UserSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "b2e9f94b-0c6c-475b-bb85-3132c7f67123");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "LastSeen" },
                values: new object[] { "22502ed0-d0b3-4522-aa97-2751a857d0b3", new DateTime(2021, 1, 23, 19, 35, 2, 643, DateTimeKind.Local).AddTicks(1746), new DateTime(2021, 1, 23, 19, 35, 2, 641, DateTimeKind.Local).AddTicks(3556) });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ThreadUserSettings_SubscriptionsId",
                table: "ThreadUserSettings",
                column: "SubscriptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_UserId",
                table: "UserSettings",
                column: "UserId",
                unique: true);
        }
    }
}
