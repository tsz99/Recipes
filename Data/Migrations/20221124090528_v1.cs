using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipes.Data.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    table.PrimaryKey("PK_Equipments", x => x.DB_ID);
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
                    table.PrimaryKey("PK_Ingredients", x => x.DB_ID);
                });

            migrationBuilder.CreateTable(
                name: "Metrics",
                columns: table => new
                {
                    DB_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(nullable: false),
                    UnitShort = table.Column<string>(nullable: true),
                    UnitLong = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metrics", x => x.DB_ID);
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
                name: "StepEquipments",
                columns: table => new
                {
                    StepId = table.Column<int>(nullable: false),
                    EquipmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepEquipments", x => new { x.StepId, x.EquipmentId });
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
                name: "Us",
                columns: table => new
                {
                    DB_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(nullable: false),
                    UnitShort = table.Column<string>(nullable: true),
                    UnitLong = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Us", x => x.DB_ID);
                });


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
                    table.ForeignKey(
                        name: "FK_AnalyzedInstructions_Recipes_RecipeDB_ID",
                        column: x => x.RecipeDB_ID,
                        principalTable: "Recipes",
                        principalColumn: "DB_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    DB_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsDB_ID = table.Column<int>(nullable: true),
                    MetricDB_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => x.DB_ID);
                    table.ForeignKey(
                        name: "FK_Measures_Metrics_MetricDB_ID",
                        column: x => x.MetricDB_ID,
                        principalTable: "Metrics",
                        principalColumn: "DB_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Measures_Us_UsDB_ID",
                        column: x => x.UsDB_ID,
                        principalTable: "Us",
                        principalColumn: "DB_ID",
                        onDelete: ReferentialAction.Restrict);
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
                    MeasuresDB_ID = table.Column<int>(nullable: true),
                    RecipeDB_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtendedIngredients", x => x.DB_ID);
                    table.ForeignKey(
                        name: "FK_ExtendedIngredients_Measures_MeasuresDB_ID",
                        column: x => x.MeasuresDB_ID,
                        principalTable: "Measures",
                        principalColumn: "DB_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExtendedIngredients_Recipes_RecipeDB_ID",
                        column: x => x.RecipeDB_ID,
                        principalTable: "Recipes",
                        principalColumn: "DB_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalyzedInstructions_RecipeDB_ID",
                table: "AnalyzedInstructions",
                column: "RecipeDB_ID");

          
            migrationBuilder.CreateIndex(
                name: "IX_ExtendedIngredients_MeasuresDB_ID",
                table: "ExtendedIngredients",
                column: "MeasuresDB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ExtendedIngredients_RecipeDB_ID",
                table: "ExtendedIngredients",
                column: "RecipeDB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Measures_MetricDB_ID",
                table: "Measures",
                column: "MetricDB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Measures_UsDB_ID",
                table: "Measures",
                column: "UsDB_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalyzedInstructions");

            migrationBuilder.DropTable(
                name: "AnalyzedInstructionSteps");

         
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
                name: "StepEquipments");

            migrationBuilder.DropTable(
                name: "StepIngredients");

            migrationBuilder.DropTable(
                name: "Steps");


            migrationBuilder.DropTable(
                name: "Measures");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Metrics");

            migrationBuilder.DropTable(
                name: "Us");
        }
    }
}
