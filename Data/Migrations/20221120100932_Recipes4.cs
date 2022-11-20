using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipes.Data.Migrations
{
    public partial class Recipes4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Image", "ImageType", "Title" },
                values: new object[] { 2, "url", "png", "Recipe_2" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Image", "ImageType", "Title" },
                values: new object[] { 3, "url", "png", "Recipe_3" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Image", "ImageType", "Title" },
                values: new object[] { 4, "url", "png", "Recipe_4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
