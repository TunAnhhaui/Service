using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class update25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Payment",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingStatus",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Chưa chuyển");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Payment",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "ShippingStatus",
                table: "orders");
        }
    }
}
