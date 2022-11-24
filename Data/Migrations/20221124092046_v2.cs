using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipes.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtendedIngredients_Measures_MeasuresDB_ID",
                table: "ExtendedIngredients");

            migrationBuilder.DropTable(
                name: "Measures");

            migrationBuilder.DropTable(
                name: "Metrics");

            migrationBuilder.DropTable(
                name: "Us");

            migrationBuilder.DropIndex(
                name: "IX_ExtendedIngredients_MeasuresDB_ID",
                table: "ExtendedIngredients");

            migrationBuilder.DropColumn(
                name: "MeasuresDB_ID",
                table: "ExtendedIngredients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeasuresDB_ID",
                table: "ExtendedIngredients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Metrics",
                columns: table => new
                {
                    DB_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    UnitLong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitShort = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metrics", x => x.DB_ID);
                });

            migrationBuilder.CreateTable(
                name: "Us",
                columns: table => new
                {
                    DB_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    UnitLong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitShort = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Us", x => x.DB_ID);
                });

            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    DB_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetricDB_ID = table.Column<int>(type: "int", nullable: true),
                    UsDB_ID = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_ExtendedIngredients_MeasuresDB_ID",
                table: "ExtendedIngredients",
                column: "MeasuresDB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Measures_MetricDB_ID",
                table: "Measures",
                column: "MetricDB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Measures_UsDB_ID",
                table: "Measures",
                column: "UsDB_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtendedIngredients_Measures_MeasuresDB_ID",
                table: "ExtendedIngredients",
                column: "MeasuresDB_ID",
                principalTable: "Measures",
                principalColumn: "DB_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
