using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class userseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessLevel", "AchievementNum", "Email", "FoundLocationNum", "Hashpassword", "LevelPoints", "Name", "Password" },
                values: new object[] { 1, 0, 10, "mrhamster@gmail.com", 23, new byte[] { 21, 38, 44, 23, 2, 171, 15, 221, 119, 242, 49, 206, 209, 1, 142, 230, 198, 205, 247, 107, 74, 54, 221, 49, 170, 135, 107, 6, 239, 179, 213, 51 }, 8520, "Hamster", "ilovehamsters" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessLevel", "AchievementNum", "Email", "FoundLocationNum", "Hashpassword", "LevelPoints", "Name", "Password" },
                values: new object[] { 2, 0, 10, "mrcamster@gmail.com", 23, new byte[] { 21, 38, 44, 23, 2, 171, 15, 221, 119, 242, 49, 206, 209, 1, 142, 230, 198, 205, 247, 107, 74, 54, 221, 49, 170, 135, 107, 6, 239, 179, 213, 51 }, 8520, "Camster", "ilovecamsters" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
