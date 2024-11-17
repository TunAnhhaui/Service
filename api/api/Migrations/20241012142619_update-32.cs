using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class update32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_userPromotion_PromotionId",
                table: "userPromotion",
                column: "PromotionId");

            migrationBuilder.AddForeignKey(
                name: "FK_userPromotion_promotion_PromotionId",
                table: "userPromotion",
                column: "PromotionId",
                principalTable: "promotion",
                principalColumn: "PromotionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userPromotion_promotion_PromotionId",
                table: "userPromotion");

            migrationBuilder.DropIndex(
                name: "IX_userPromotion_PromotionId",
                table: "userPromotion");
        }
    }
}
