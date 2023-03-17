using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWWW_lab2_gr5.Migrations
{
    /// <inheritdoc />
    public partial class AddMatchEventMatchRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatchEventId",
                table: "MatchEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "MatchEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MatchEvents_MatchId",
                table: "MatchEvents",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchEvents_Matches_MatchId",
                table: "MatchEvents",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchEvents_Matches_MatchId",
                table: "MatchEvents");

            migrationBuilder.DropIndex(
                name: "IX_MatchEvents_MatchId",
                table: "MatchEvents");

            migrationBuilder.DropColumn(
                name: "MatchEventId",
                table: "MatchEvents");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "MatchEvents");
        }
    }
}
