using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS2.Migrations
{
    /// <inheritdoc />
    public partial class Hope6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Quests_QuestId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "QuestId",
                table: "Items",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Quests_QuestId",
                table: "Items",
                column: "QuestId",
                principalTable: "Quests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Quests_QuestId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "QuestId",
                table: "Items",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Quests_QuestId",
                table: "Items",
                column: "QuestId",
                principalTable: "Quests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
