using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SneakerDAL.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Orders_orderId1",
                table: "Buys");

            migrationBuilder.DropIndex(
                name: "IX_Buys_orderId1",
                table: "Buys");

            migrationBuilder.RenameColumn(
                name: "orderId1",
                table: "Buys",
                newName: "OrderId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Buys",
                newName: "orderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Buys_orderId1",
                table: "Buys",
                column: "orderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Orders_orderId1",
                table: "Buys",
                column: "orderId1",
                principalTable: "Orders",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
