using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.LeaveManagement.Identity.Migrations
{
    /// <inheritdoc />
    public partial class InitIdentityChangeHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELbv1MEhKiQQxhZqTYlqD6Y6rJPO++K2Yib1lR3rLctJKDRyZOrFMwKXD2go34HL5w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd15-6342-4840-95c2-db12554843e5",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELbv1MEhKiQQxhZqTYlqD6Y6rJPO++K2Yib1lR3rLctJKDRyZOrFMwKXD2go34HL5w==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELMKnhFX2TbXVA5KgfIfpOGJmJv8cN4Rl1X3p1Hs2QGh7K8zE9k3N2QyV7b6A4cF8D==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd15-6342-4840-95c2-db12554843e5",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELMKnhFX2TbXVA5KgfIfpOGJmJv8cN4Rl1X3p1Hs2QGh7K8zE9k3N2QyV7b6A4cF8D==");
        }
    }
}
