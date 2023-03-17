using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWWW_lab2_gr5.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayerMatchPlayerRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "MatchPlayers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayers_PlayerId",
                table: "MatchPlayers",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayers_Players_PlayerId",
                table: "MatchPlayers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayers_Players_PlayerId",
                table: "MatchPlayers");

            migrationBuilder.DropIndex(
                name: "IX_MatchPlayers_PlayerId",
                table: "MatchPlayers");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "MatchPlayers");
        }
    }
}
