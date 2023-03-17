using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWWW_lab2_gr5.Migrations
{
    /// <inheritdoc />
    public partial class AddMPlayerMEventRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "MatchPlayers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MatchPlayerId",
                table: "MatchEvents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayers_MatchId",
                table: "MatchPlayers",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchEvents_MatchPlayerId",
                table: "MatchEvents",
                column: "MatchPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchEvents_MatchPlayers_MatchPlayerId",
                table: "MatchEvents",
                column: "MatchPlayerId",
                principalTable: "MatchPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayers_Matches_MatchId",
                table: "MatchPlayers",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchEvents_MatchPlayers_MatchPlayerId",
                table: "MatchEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayers_Matches_MatchId",
                table: "MatchPlayers");

            migrationBuilder.DropIndex(
                name: "IX_MatchPlayers_MatchId",
                table: "MatchPlayers");

            migrationBuilder.DropIndex(
                name: "IX_MatchEvents_MatchPlayerId",
                table: "MatchEvents");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "MatchPlayers");

            migrationBuilder.DropColumn(
                name: "MatchPlayerId",
                table: "MatchEvents");
        }
    }
}
