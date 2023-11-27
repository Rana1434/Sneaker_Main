using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SneakerDAL.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Orders_OrderId",
                table: "Buys");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Buys",
                newName: "orderId");

            migrationBuilder.RenameIndex(
                name: "IX_Buys_OrderId",
                table: "Buys",
                newName: "IX_Buys_orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Orders_orderId",
                table: "Buys",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Orders_orderId",
                table: "Buys");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "Buys",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Buys_orderId",
                table: "Buys",
                newName: "IX_Buys_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Orders_OrderId",
                table: "Buys",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
