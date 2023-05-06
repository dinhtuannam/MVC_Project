using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removeroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4dcaba5c-44b9-4dc8-aece-b5bab1dd2ae2", "AQAAAAIAAYagAAAAEA86dHjLajI7iUYrremXeTUJrC4xwrbjinCt/Y0Bj5g5p2GiQZ26WSprt8c6DR8xAQ==", "15da26ca-ff31-4cd2-85b6-0a66dd95c027" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32da4317-6ab1-4f96-945a-afb2480527ed", "AQAAAAIAAYagAAAAEGpVVxSpgVXDOpwSFM+AyhVnVYsrB8zVWki52hOoqFe3o6VX5WXXkapBg6QpBAQ1vw==", "6051219d-69ff-4bb1-8119-2c288bac5d52" });
        }
    }
}
