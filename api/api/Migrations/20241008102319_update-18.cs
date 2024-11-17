using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class update18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "orders",
              columns: table => new
              {
                  OrderId = table.Column<int>(nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  UserId = table.Column<int>(nullable: false),
                  ProductId = table.Column<int>(nullable: false),
                  Quantity = table.Column<int>(nullable: false),
                  Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  CreateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(1, 1, 1))
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_orders", x => x.OrderId);
              });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
