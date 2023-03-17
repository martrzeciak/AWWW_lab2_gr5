using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWWW_lab2_gr5.Migrations
{
    /// <inheritdoc />
    public partial class AddMatchPlayerPositionRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "MatchPlayers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayers_PositionId",
                table: "MatchPlayers",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayers_Positions_PositionId",
                table: "MatchPlayers",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayers_Positions_PositionId",
                table: "MatchPlayers");

            migrationBuilder.DropIndex(
                name: "IX_MatchPlayers_PositionId",
                table: "MatchPlayers");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "MatchPlayers");
        }
    }
}
