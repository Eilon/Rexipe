using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RexipeMobile.MobileAppService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemQuantities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numerator = table.Column<int>(nullable: false),
                    Denominator = table.Column<int>(nullable: false),
                    Unit = table.Column<int>(nullable: false),
                    OtherUnit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemQuantities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NutritionInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Calories = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeAuthors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    ServingsMin = table.Column<int>(nullable: false),
                    ServingsMax = table.Column<int>(nullable: false),
                    NutritionInfoId = table.Column<int>(nullable: true),
                    PrepTime = table.Column<TimeSpan>(nullable: false),
                    CookTime = table.Column<TimeSpan>(nullable: false),
                    ReadyTime = table.Column<TimeSpan>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_RecipeAuthors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "RecipeAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_NutritionInfo_NutritionInfoId",
                        column: x => x.NutritionInfoId,
                        principalTable: "NutritionInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Caption = table.Column<string>(nullable: true),
                    Bytes = table.Column<byte[]>(nullable: false),
                    RecipeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeDirections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Direction = table.Column<string>(nullable: false),
                    RecipeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDirections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeDirections_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ImageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeTip",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: false),
                    ImageId = table.Column<int>(nullable: true),
                    RecipeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeTip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeTip_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeTip_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngredientQuantities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IngredientId = table.Column<int>(nullable: false),
                    QuantityId = table.Column<int>(nullable: true),
                    RecipeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientQuantities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientQuantities_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientQuantities_ItemQuantities_QuantityId",
                        column: x => x.QuantityId,
                        principalTable: "ItemQuantities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngredientQuantities_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_RecipeId",
                table: "Image",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientQuantities_IngredientId",
                table: "IngredientQuantities",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientQuantities_QuantityId",
                table: "IngredientQuantities",
                column: "QuantityId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientQuantities_RecipeId",
                table: "IngredientQuantities",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_ImageId",
                table: "Ingredients",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDirections_RecipeId",
                table: "RecipeDirections",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_AuthorId",
                table: "Recipes",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_NutritionInfoId",
                table: "Recipes",
                column: "NutritionInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTip_ImageId",
                table: "RecipeTip",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTip_RecipeId",
                table: "RecipeTip",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientQuantities");

            migrationBuilder.DropTable(
                name: "RecipeDirections");

            migrationBuilder.DropTable(
                name: "RecipeTip");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "ItemQuantities");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "RecipeAuthors");

            migrationBuilder.DropTable(
                name: "NutritionInfo");
        }
    }
}
