using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS2.Migrations
{
    /// <inheritdoc />
    public partial class Hope7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campains_GameMasters_GameMasterId",
                table: "Campains");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_GameMasters_GameMasterId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "GameMasterId",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_GameMasterId",
                table: "Users",
                newName: "IX_Users_UserId");

            migrationBuilder.RenameColumn(
                name: "GameMasterId",
                table: "Campains",
                newName: "CampainId");

            migrationBuilder.RenameIndex(
                name: "IX_Campains_GameMasterId",
                table: "Campains",
                newName: "IX_Campains_CampainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campains_GameMasters_CampainId",
                table: "Campains",
                column: "CampainId",
                principalTable: "GameMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GameMasters_UserId",
                table: "Users",
                column: "UserId",
                principalTable: "GameMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campains_GameMasters_CampainId",
                table: "Campains");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_GameMasters_UserId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "GameMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserId",
                table: "Users",
                newName: "IX_Users_GameMasterId");

            migrationBuilder.RenameColumn(
                name: "CampainId",
                table: "Campains",
                newName: "GameMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_Campains_CampainId",
                table: "Campains",
                newName: "IX_Campains_GameMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campains_GameMasters_GameMasterId",
                table: "Campains",
                column: "GameMasterId",
                principalTable: "GameMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GameMasters_GameMasterId",
                table: "Users",
                column: "GameMasterId",
                principalTable: "GameMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
