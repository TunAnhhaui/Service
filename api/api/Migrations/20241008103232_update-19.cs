using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class update19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ordersItem",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordersItem", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_ordersItem_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordersItem_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ordersItem_OrderId",
                table: "ordersItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ordersItem_ProductId",
                table: "ordersItem",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
