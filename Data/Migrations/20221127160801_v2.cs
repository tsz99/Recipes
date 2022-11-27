using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipes.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
        name: "RecipeExtendedIngredients");

            migrationBuilder.DropTable(
                name: "ExtendedIngredients");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExtendedIngredients",
                columns: table => new
                {
                    DB_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aisle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Consistency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameClean = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Original = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipeDB_ID = table.Column<int>(type: "int", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtendedIngredients", x => x.DB_ID);
                    table.ForeignKey(
                        name: "FK_ExtendedIngredients_Recipes_RecipeDB_ID",
                        column: x => x.RecipeDB_ID,
                        principalTable: "Recipes",
                        principalColumn: "DB_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeExtendedIngredients",
                columns: table => new
                {
                    ExtendedIngredientId = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeExtendedIngredients", x => new { x.ExtendedIngredientId, x.RecipeId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtendedIngredients_RecipeDB_ID",
                table: "ExtendedIngredients",
                column: "RecipeDB_ID");
        }
    }
}
