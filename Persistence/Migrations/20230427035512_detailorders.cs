using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class detailorders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DetailOrders_OrderId",
                table: "DetailOrders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailOrders",
                table: "DetailOrders",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c285feee-f360-41f9-8861-2f8631c25ab4", "AQAAAAIAAYagAAAAENfSQ690xoL9WK8f1MXlb9s37i82FnO6R4kWQmTd5jn65UN0aIfze3V5WVrihemkTg==", "3942bd93-17ed-4cb3-b453-d750e396b0e6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailOrders",
                table: "DetailOrders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9728bdb-b9c7-4507-bc3d-613975551cea", "AQAAAAIAAYagAAAAENM1vpzwCcFF6xCQEwSeuIFNuc5UZyN+wb/87LpqDF8uvmkKVd1BtXOQNweVGOyiNw==", "674b3f9b-a683-4f0f-995b-e182385fcaed" });

            migrationBuilder.CreateIndex(
                name: "IX_DetailOrders_OrderId",
                table: "DetailOrders",
                column: "OrderId");
        }
    }
}
