using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SneakerDAL.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    custId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    custName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    custAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.custId);
                });

            migrationBuilder.CreateTable(
                name: "Shoes",
                columns: table => new
                {
                    shoeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shoePrice = table.Column<double>(type: "float", nullable: true),
                    shoeStyle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shoeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shoeColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shoeSize = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoes", x => x.shoeId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomercustId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customer_CustomercustId",
                        column: x => x.CustomercustId,
                        principalTable: "Customer",
                        principalColumn: "custId");
                });

            migrationBuilder.CreateTable(
                name: "Buys",
                columns: table => new
                {
                    orderedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shoeId = table.Column<int>(type: "int", nullable: false),
                    orderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buys", x => x.orderedId);
                    table.ForeignKey(
                        name: "FK_Buys_Orders_orderId",
                        column: x => x.orderId,
                        principalTable: "Orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buys_Shoes_shoeId",
                        column: x => x.shoeId,
                        principalTable: "Shoes",
                        principalColumn: "shoeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buys_orderId",
                table: "Buys",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_Buys_shoeId",
                table: "Buys",
                column: "shoeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomercustId",
                table: "Orders",
                column: "CustomercustId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buys");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Shoes");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
