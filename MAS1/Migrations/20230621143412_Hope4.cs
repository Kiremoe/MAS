using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS2.Migrations
{
    /// <inheritdoc />
    public partial class Hope4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CamapinFK",
                table: "CampainZone",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZoneFK",
                table: "CampainZone",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CampainZone_CamapinFK",
                table: "CampainZone",
                column: "CamapinFK");

            migrationBuilder.CreateIndex(
                name: "IX_CampainZone_ZoneFK",
                table: "CampainZone",
                column: "ZoneFK");

            migrationBuilder.AddForeignKey(
                name: "FK_CampainZone_Campains_CamapinFK",
                table: "CampainZone",
                column: "CamapinFK",
                principalTable: "Campains",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CampainZone_Zones_ZoneFK",
                table: "CampainZone",
                column: "ZoneFK",
                principalTable: "Zones",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampainZone_Campains_CamapinFK",
                table: "CampainZone");

            migrationBuilder.DropForeignKey(
                name: "FK_CampainZone_Zones_ZoneFK",
                table: "CampainZone");

            migrationBuilder.DropIndex(
                name: "IX_CampainZone_CamapinFK",
                table: "CampainZone");

            migrationBuilder.DropIndex(
                name: "IX_CampainZone_ZoneFK",
                table: "CampainZone");

            migrationBuilder.DropColumn(
                name: "CamapinFK",
                table: "CampainZone");

            migrationBuilder.DropColumn(
                name: "ZoneFK",
                table: "CampainZone");
        }
    }
}
