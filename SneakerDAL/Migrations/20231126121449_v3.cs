using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SneakerDAL.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Orders_orderId",
                table: "Buys");

            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Shoes_shoeId",
                table: "Buys");

            migrationBuilder.RenameColumn(
                name: "shoeId",
                table: "Buys",
                newName: "shoeId1");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "Buys",
                newName: "orderId1");

            migrationBuilder.RenameIndex(
                name: "IX_Buys_shoeId",
                table: "Buys",
                newName: "IX_Buys_shoeId1");

            migrationBuilder.RenameIndex(
                name: "IX_Buys_orderId",
                table: "Buys",
                newName: "IX_Buys_orderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Orders_orderId1",
                table: "Buys",
                column: "orderId1",
                principalTable: "Orders",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Shoes_shoeId1",
                table: "Buys",
                column: "shoeId1",
                principalTable: "Shoes",
                principalColumn: "shoeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Orders_orderId1",
                table: "Buys");

            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Shoes_shoeId1",
                table: "Buys");

            migrationBuilder.RenameColumn(
                name: "shoeId1",
                table: "Buys",
                newName: "shoeId");

            migrationBuilder.RenameColumn(
                name: "orderId1",
                table: "Buys",
                newName: "orderId");

            migrationBuilder.RenameIndex(
                name: "IX_Buys_shoeId1",
                table: "Buys",
                newName: "IX_Buys_shoeId");

            migrationBuilder.RenameIndex(
                name: "IX_Buys_orderId1",
                table: "Buys",
                newName: "IX_Buys_orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Orders_orderId",
                table: "Buys",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Shoes_shoeId",
                table: "Buys",
                column: "shoeId",
                principalTable: "Shoes",
                principalColumn: "shoeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
