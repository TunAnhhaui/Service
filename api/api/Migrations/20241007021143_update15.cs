using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class update15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_colors_ColorId",
                table: "ProductColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_products_ProductId",
                table: "ProductColor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductColor",
                table: "ProductColor");

            migrationBuilder.RenameTable(
                name: "ProductColor",
                newName: "productColors");

            migrationBuilder.RenameIndex(
                name: "IX_ProductColor_ProductId",
                table: "productColors",
                newName: "IX_productColors_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductColor_ColorId",
                table: "productColors",
                newName: "IX_productColors_ColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productColors",
                table: "productColors",
                column: "ProductColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_productColors_colors_ColorId",
                table: "productColors",
                column: "ColorId",
                principalTable: "colors",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productColors_products_ProductId",
                table: "productColors",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productColors_colors_ColorId",
                table: "productColors");

            migrationBuilder.DropForeignKey(
                name: "FK_productColors_products_ProductId",
                table: "productColors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productColors",
                table: "productColors");

            migrationBuilder.RenameTable(
                name: "productColors",
                newName: "ProductColor");

            migrationBuilder.RenameIndex(
                name: "IX_productColors_ProductId",
                table: "ProductColor",
                newName: "IX_ProductColor_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_productColors_ColorId",
                table: "ProductColor",
                newName: "IX_ProductColor_ColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductColor",
                table: "ProductColor",
                column: "ProductColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_colors_ColorId",
                table: "ProductColor",
                column: "ColorId",
                principalTable: "colors",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_products_ProductId",
                table: "ProductColor",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
