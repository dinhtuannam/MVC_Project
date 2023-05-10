using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class category_status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Categories",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9484765-6014-4971-b78c-70b132eb9666", "AQAAAAIAAYagAAAAEPjy/3023+G0Iv8GIzC7iO/u9dgDw2bq8en7SvNXVlkzKyTkosgEPQvVsOyVTNu9Tw==", "9d4e812c-c060-4285-bff7-e103cf76c37a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4b7da7c-88f2-47ac-a056-bf54c2dbf16d", "AQAAAAIAAYagAAAAEN4NeKtAFgohKK1IvHVolzRZfi0nL2xglUBR8LubDr7JXEknXerPjoEq6mfArsDMjw==", "f9a53f04-e71a-4ad4-a4e1-2f1878a4efa2" });
        }
    }
}
