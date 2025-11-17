using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.LeaveManagement.Identity.Migrations
{
    /// <inheritdoc />
    public partial class InitIdentityMigrationChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8554266-b401-4519-9aeb-b5c87a9c3c2e", "AQAAAAIAAYagAAAAELMKnhFX2TbXVA5KgfIfpOGJmJv8cN4Rl1X3p1Hs2QGh7K8zE9k3N2QyV7b6A4cF8D==", "JXESUAHBQEBJ4EYBCQZQV4KSRTRSQ2L2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd15-6342-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8554266-b401-4519-9aeb-b5c87a9c3c2f", "AQAAAAIAAYagAAAAELMKnhFX2TbXVA5KgfIfpOGJmJv8cN4Rl1X3p1Hs2QGh7K8zE9k3N2QyV7b6A4cF8D==", "JXESUAHBQEBJ4EYBCQZQV4KSRTRSQ2L3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "854f1ea4-4c41-488f-ac86-ac13d6c922f9", "AQAAAAIAAYagAAAAEGy2rJ0KlbT0WnivN0RlGhpkzTVtwFsyVsUoX8ZX0ZgtrgIDDMZ/omgrXVYZIapl1g==", "e70bd7d4-6477-4b14-ab86-0a8e2224996b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd15-6342-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f94c3f4-0874-4767-aed7-e4256deeffab", "AQAAAAIAAYagAAAAEGbSJgbF4/PGpKipjonsfvHqnX2d05++iyT8qdEOb+pr1I/2191+XlVw2fQVIN11Lw==", "b31dc826-49b9-4a39-a4b2-ae1191da51b7" });
        }
    }
}
