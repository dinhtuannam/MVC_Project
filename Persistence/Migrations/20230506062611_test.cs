using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Accounts_AccountsId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AccountsId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AccountsId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0adfffd-3f4e-45d8-ab29-ee74dd5f9813", "AQAAAAIAAYagAAAAEGUZXsuHpmsjvhpMYe47GUEIiFz40gGb9b+C6TxvQNlXOgfTR2OO/X5G0TIcvnNOJw==", "4ec00573-0162-43f6-97e8-46b55d7a15e4" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountId",
                table: "Orders",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_AccountId",
                table: "Orders",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_AccountId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AccountId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "AccountsId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c285feee-f360-41f9-8861-2f8631c25ab4", "AQAAAAIAAYagAAAAENfSQ690xoL9WK8f1MXlb9s37i82FnO6R4kWQmTd5jn65UN0aIfze3V5WVrihemkTg==", "3942bd93-17ed-4cb3-b453-d750e396b0e6" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountsId",
                table: "Orders",
                column: "AccountsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Accounts_AccountsId",
                table: "Orders",
                column: "AccountsId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
