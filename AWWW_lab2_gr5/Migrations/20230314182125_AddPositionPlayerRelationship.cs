using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWWW_lab2_gr5.Migrations
{
    /// <inheritdoc />
    public partial class AddPositionPlayerRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PositionPlayer",
                columns: table => new
                {
                    PlayersManyToManyRelationshipId = table.Column<int>(type: "int", nullable: false),
                    PositionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionPlayer", x => new { x.PlayersManyToManyRelationshipId, x.PositionsId });
                    table.ForeignKey(
                        name: "FK_PositionPlayer_Players_PlayersManyToManyRelationshipId",
                        column: x => x.PlayersManyToManyRelationshipId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionPlayer_Positions_PositionsId",
                        column: x => x.PositionsId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_PositionId",
                table: "Players",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionPlayer_PositionsId",
                table: "PositionPlayer",
                column: "PositionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Positions_PositionId",
                table: "Players",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Positions_PositionId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "PositionPlayer");

            migrationBuilder.DropIndex(
                name: "IX_Players_PositionId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Players");
        }
    }
}
