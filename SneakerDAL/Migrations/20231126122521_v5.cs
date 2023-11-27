using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SneakerDAL.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Orders_OrdersorderId",
                table: "Buys");

            migrationBuilder.DropIndex(
                name: "IX_Buys_OrdersorderId",
                table: "Buys");

            migrationBuilder.DropColumn(
                name: "OrdersorderId",
                table: "Buys");

            migrationBuilder.CreateIndex(
                name: "IX_Buys_OrderId",
                table: "Buys",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Orders_OrderId",
                table: "Buys",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Orders_OrderId",
                table: "Buys");

            migrationBuilder.DropIndex(
                name: "IX_Buys_OrderId",
                table: "Buys");

            migrationBuilder.AddColumn<int>(
                name: "OrdersorderId",
                table: "Buys",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buys_OrdersorderId",
                table: "Buys",
                column: "OrdersorderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Orders_OrdersorderId",
                table: "Buys",
                column: "OrdersorderId",
                principalTable: "Orders",
                principalColumn: "orderId");
        }
    }
}
