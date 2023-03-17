using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWWW_lab2_gr5.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayerTeamRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_TeamId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Players");
        }
    }
}
