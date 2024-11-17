using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class update7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "productSizes");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ProductColor");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductColor");

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "productSizes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "ProductColor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "colors",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colors", x => x.ColorId);
                });

            migrationBuilder.CreateTable(
                name: "sizes",
                columns: table => new
                {
                    SizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sizes", x => x.SizeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productSizes_SizeId",
                table: "productSizes",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColor_ColorId",
                table: "ProductColor",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_colors_ColorId",
                table: "ProductColor",
                column: "ColorId",
                principalTable: "colors",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productSizes_sizes_SizeId",
                table: "productSizes",
                column: "SizeId",
                principalTable: "sizes",
                principalColumn: "SizeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_colors_ColorId",
                table: "ProductColor");

            migrationBuilder.DropForeignKey(
                name: "FK_productSizes_sizes_SizeId",
                table: "productSizes");

            migrationBuilder.DropTable(
                name: "colors");

            migrationBuilder.DropTable(
                name: "sizes");

            migrationBuilder.DropIndex(
                name: "IX_productSizes_SizeId",
                table: "productSizes");

            migrationBuilder.DropIndex(
                name: "IX_ProductColor_ColorId",
                table: "ProductColor");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "productSizes");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "ProductColor");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "productSizes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ProductColor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductColor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
