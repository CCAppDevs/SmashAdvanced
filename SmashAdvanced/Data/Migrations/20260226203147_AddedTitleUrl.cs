using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmashAdvanced.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTitleUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TitleImageGameScreenshotId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Games_TitleImageGameScreenshotId",
                table: "Games",
                column: "TitleImageGameScreenshotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_GameScreenshots_TitleImageGameScreenshotId",
                table: "Games",
                column: "TitleImageGameScreenshotId",
                principalTable: "GameScreenshots",
                principalColumn: "GameScreenshotId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_GameScreenshots_TitleImageGameScreenshotId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_TitleImageGameScreenshotId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "TitleImageGameScreenshotId",
                table: "Games");
        }
    }
}
