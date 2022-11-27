using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipes.Data.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
    name: "AnalyzedInstructions",
    columns: table => new
    {
        DB_ID = table.Column<int>(nullable: false)
            .Annotation("SqlServer:Identity", "1, 1"),
        Name = table.Column<string>(nullable: true),
        RecipeDB_ID = table.Column<int>(nullable: true)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_AnalyzedInstructions", x => x.DB_ID);
    });
            migrationBuilder.CreateTable(
    name: "ExtendedIngredients",
    columns: table => new
    {
        DB_ID = table.Column<int>(nullable: false)
            .Annotation("SqlServer:Identity", "1, 1"),
        Id = table.Column<int>(nullable: false),
        Aisle = table.Column<string>(nullable: true),
        Image = table.Column<string>(nullable: true),
        Consistency = table.Column<string>(nullable: true),
        Name = table.Column<string>(nullable: true),
        NameClean = table.Column<string>(nullable: true),
        Original = table.Column<string>(nullable: true),
        OriginalName = table.Column<string>(nullable: true),
        Amount = table.Column<double>(nullable: false),
        Unit = table.Column<string>(nullable: true),
        RecipeDB_ID = table.Column<int>(nullable: true)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_ExtendedIngredients", x => x.DB_ID);
    });
           

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    DB_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LocalizedName = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    DB_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LocalizedName = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

           

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    DB_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vegetarian = table.Column<bool>(nullable: false),
                    Vegan = table.Column<bool>(nullable: false),
                    GlutenFree = table.Column<bool>(nullable: false),
                    DairyFree = table.Column<bool>(nullable: false),
                    VeryHealthy = table.Column<bool>(nullable: false),
                    Cheap = table.Column<bool>(nullable: false),
                    VeryPopular = table.Column<bool>(nullable: false),
                    Sustainable = table.Column<bool>(nullable: false),
                    LowFodmap = table.Column<bool>(nullable: false),
                    WeightWatcherSmartPoints = table.Column<int>(nullable: false),
                    Gaps = table.Column<string>(nullable: true),
                    PreparationMinutes = table.Column<int>(nullable: false),
                    CookingMinutes = table.Column<int>(nullable: false),
                    AggregateLikes = table.Column<int>(nullable: false),
                    HealthScore = table.Column<int>(nullable: false),
                    CreditsText = table.Column<string>(nullable: true),
                    License = table.Column<string>(nullable: true),
                    SourceName = table.Column<string>(nullable: true),
                    PricePerServing = table.Column<double>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    ReadyInMinutes = table.Column<int>(nullable: false),
                    Servings = table.Column<int>(nullable: false),
                    SourceUrl = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    ImageType = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Instructions = table.Column<string>(nullable: true),
                    SpoonacularSourceUrl = table.Column<string>(nullable: true),
                    CreatorUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.DB_ID);
                });


            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    StepId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    StepDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.StepId);
                });

           

            migrationBuilder.CreateTable(
                name: "StepEquipments",
                columns: table => new
                {
                    StepId = table.Column<int>(nullable: false),
                    EquipmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepEquipments", x => new { x.StepId, x.EquipmentId });
                    table.ForeignKey(
                            name: "FK_StepEquipments_Equipments_DBID",
                            column: x => x.EquipmentId,
                            principalTable: "Equipments",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                            name: "FK_StepEquipments_Steps_DBID",
                            column: x => x.StepId,
                            principalTable: "Steps",
                            principalColumn: "StepId",
                            onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StepIngredients",
                columns: table => new
                {
                    StepId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepIngredients", x => new { x.StepId, x.IngredientId });
                    table.ForeignKey(
                            name: "FK_StepIngredients_Ingredients_DBID",
                            column: x => x.IngredientId,
                            principalTable: "Ingredients",
                            principalColumn: "IngredientId",
                            onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                            name: "FK_StepIngredients_Steps_DBID",
                            column: x => x.StepId,
                            principalTable: "Steps",
                            principalColumn: "StepId",
                            onDelete: ReferentialAction.Cascade);
                });



            migrationBuilder.CreateTable(
               name: "RecipeAnalyzedInstructions",
               columns: table => new
               {
                   RecipeId = table.Column<int>(nullable: false),
                   AnalyzedInstructionId = table.Column<int>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_RecipeAnalyzedInstructions", x => new { x.AnalyzedInstructionId, x.RecipeId });
                   table.ForeignKey(
                           name: "FK_RecipeAnalyzedInstructions_AnalyzedInstructions_DBID",
                           column: x => x.AnalyzedInstructionId,
                           principalTable: "AnalyzedInstructions",
                           principalColumn: "DB_ID",
                           onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                           name: "FK_RecipeAnalyzedInstructions_Recipes_DBID",
                           column: x => x.RecipeId,
                           principalTable: "Recipes",
                           principalColumn: "DB_ID",
                           onDelete: ReferentialAction.Cascade);
               });

            migrationBuilder.CreateTable(
                name: "RecipeExtendedIngredients",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false),
                    ExtendedIngredientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeExtendedIngredients", x => new { x.ExtendedIngredientId, x.RecipeId });
                    table.ForeignKey(
                            name: "FK_RecipeExtendedIngredients_ExtendedIngredients_DBID",
                            column: x => x.ExtendedIngredientId,
                            principalTable: "ExtendedIngredients",
                            principalColumn: "DB_ID",
                            onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                            name: "FK_RecipeExtendedIngredients_Recipes_DBID",
                            column: x => x.RecipeId,
                            principalTable: "Recipes",
                            principalColumn: "DB_ID",
                            onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => new { x.RecipeId, x.IngredientId });
                    table.ForeignKey(
                            name: "FK_RecipeIngredients_Ingredients_DBID",
                            column: x => x.IngredientId,
                            principalTable: "Ingredients",
                            principalColumn: "IngredientId",
                            onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                            name: "FK_RecipeIngredients_Recipes_DBID",
                            column: x => x.RecipeId,
                            principalTable: "Recipes",
                            principalColumn: "DB_ID",
                            onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
    name: "AnalyzedInstructionSteps",
    columns: table => new
    {
        AnalyzedInstructionId = table.Column<int>(nullable: false),
        StepId = table.Column<int>(nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_AnalyzedInstructionSteps", x => new { x.StepId, x.AnalyzedInstructionId });
        table.ForeignKey(
                name: "FK_AnalyzedInstructionSteps_AnalyzedInstruction_DBID",
                column: x => x.AnalyzedInstructionId,
                principalTable: "AnalyzedInstructions",
                principalColumn: "DB_ID",
                onDelete: ReferentialAction.Cascade);
        table.ForeignKey(
                name: "FK_AnalyzedInstructionSteps_Steps_DBID",
                column: x => x.StepId,
                principalTable: "Steps",
                principalColumn: "StepId",
                onDelete: ReferentialAction.Cascade);
    });
            migrationBuilder.CreateIndex(
                name: "IX_AnalyzedInstructions_RecipeDB_ID",
                table: "AnalyzedInstructions",
                column: "RecipeDB_ID");

          

            migrationBuilder.CreateIndex(
                name: "IX_ExtendedIngredients_RecipeDB_ID",
                table: "ExtendedIngredients",
                column: "RecipeDB_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalyzedInstructions");

            migrationBuilder.DropTable(
                name: "AnalyzedInstructionSteps");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "ExtendedIngredients");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "RecipeAnalyzedInstructions");

            migrationBuilder.DropTable(
                name: "RecipeExtendedIngredients");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "StepEquipments");

            migrationBuilder.DropTable(
                name: "StepIngredients");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
