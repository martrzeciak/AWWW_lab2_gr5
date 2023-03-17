using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWWW_lab2_gr5.Migrations
{
    /// <inheritdoc />
    public partial class AddEventTypeMatchEventRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventTypeId",
                table: "MatchEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MatchEvents_EventTypeId",
                table: "MatchEvents",
                column: "EventTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchEvents_EventTypes_EventTypeId",
                table: "MatchEvents",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchEvents_EventTypes_EventTypeId",
                table: "MatchEvents");

            migrationBuilder.DropIndex(
                name: "IX_MatchEvents_EventTypeId",
                table: "MatchEvents");

            migrationBuilder.DropColumn(
                name: "EventTypeId",
                table: "MatchEvents");
        }
    }
}
