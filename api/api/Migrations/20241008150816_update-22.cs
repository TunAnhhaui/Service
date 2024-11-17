using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class update22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "orders",
                type: "decimal(18,2)",
                nullable: false
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
