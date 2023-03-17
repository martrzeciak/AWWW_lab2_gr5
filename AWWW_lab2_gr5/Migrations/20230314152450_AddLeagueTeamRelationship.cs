using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWWW_lab2_gr5.Migrations
{
    /// <inheritdoc />
    public partial class AddLeagueTeamRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeagueId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams",
                column: "LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Leagues_LeagueId",
                table: "Teams",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Leagues_LeagueId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "LeagueId",
                table: "Teams");
        }
    }
}
