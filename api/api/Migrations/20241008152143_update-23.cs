using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class update23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "ProductId",
               table: "orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
