using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class abc22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4b7da7c-88f2-47ac-a056-bf54c2dbf16d", "AQAAAAIAAYagAAAAEN4NeKtAFgohKK1IvHVolzRZfi0nL2xglUBR8LubDr7JXEknXerPjoEq6mfArsDMjw==", "f9a53f04-e71a-4ad4-a4e1-2f1878a4efa2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4dcaba5c-44b9-4dc8-aece-b5bab1dd2ae2", "AQAAAAIAAYagAAAAEA86dHjLajI7iUYrremXeTUJrC4xwrbjinCt/Y0Bj5g5p2GiQZ26WSprt8c6DR8xAQ==", "15da26ca-ff31-4cd2-85b6-0a66dd95c027" });
        }
    }
}
