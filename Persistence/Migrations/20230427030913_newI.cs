using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class newI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ca8fa08-4a80-4714-a5fb-17b7316fddc4", null, "Admin", "ADMIN" },
                    { "88ac3925-8432-4f60-89e2-96433d08bbcf", null, "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ff045d07-be86-4a4e-bfa4-0264ec832c12", 0, "e9728bdb-b9c7-4507-bc3d-613975551cea", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "SUPER ADMIN", "AQAAAAIAAYagAAAAENM1vpzwCcFF6xCQEwSeuIFNuc5UZyN+wb/87LpqDF8uvmkKVd1BtXOQNweVGOyiNw==", null, false, "674b3f9b-a683-4f0f-995b-e182385fcaed", false, "Super Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2ca8fa08-4a80-4714-a5fb-17b7316fddc4", "ff045d07-be86-4a4e-bfa4-0264ec832c12" },
                    { "88ac3925-8432-4f60-89e2-96433d08bbcf", "ff045d07-be86-4a4e-bfa4-0264ec832c12" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2ca8fa08-4a80-4714-a5fb-17b7316fddc4", "ff045d07-be86-4a4e-bfa4-0264ec832c12" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "88ac3925-8432-4f60-89e2-96433d08bbcf", "ff045d07-be86-4a4e-bfa4-0264ec832c12" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ca8fa08-4a80-4714-a5fb-17b7316fddc4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ac3925-8432-4f60-89e2-96433d08bbcf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12");
        }
    }
}
