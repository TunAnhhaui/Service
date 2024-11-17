using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class update14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_products_ProductId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_users_UserId",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "comments");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserId",
                table: "comments",
                newName: "IX_comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_ProductId",
                table: "comments",
                newName: "IX_comments_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_comments",
                table: "comments",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_products_ProductId",
                table: "comments",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_users_UserId",
                table: "comments",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_products_ProductId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_users_UserId",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comments",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "comments");

            migrationBuilder.RenameTable(
                name: "comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_comments_UserId",
                table: "Comment",
                newName: "IX_Comment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_comments_ProductId",
                table: "Comment",
                newName: "IX_Comment_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_products_ProductId",
                table: "Comment",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_users_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
