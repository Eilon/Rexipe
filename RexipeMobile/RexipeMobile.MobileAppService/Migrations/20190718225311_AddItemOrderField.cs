using Microsoft.EntityFrameworkCore.Migrations;

namespace RexipeMobile.MobileAppService.Migrations
{
    public partial class AddItemOrderField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "RecipeTip",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "RecipeDirections",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "IngredientQuantities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "RecipeTip");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "RecipeDirections");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "IngredientQuantities");
        }
    }
}
