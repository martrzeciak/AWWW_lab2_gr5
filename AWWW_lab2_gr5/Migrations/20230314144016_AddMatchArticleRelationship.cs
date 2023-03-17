using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWWW_lab2_gr5.Migrations
{
    /// <inheritdoc />
    public partial class AddMatchArticleRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_MatchId",
                table: "Articles",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Matches_MatchId",
                table: "Articles",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Matches_MatchId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_MatchId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "Articles");
        }
    }
}
