using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWWW_lab2_gr5.Migrations
{
    /// <inheritdoc />
    public partial class AddTagArticleRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleTag",
                columns: table => new
                {
                    ArtcilesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTag", x => new { x.ArtcilesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ArticleTag_Articles_ArtcilesId",
                        column: x => x.ArtcilesId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTag_TagsId",
                table: "ArticleTag",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleTag");
        }
    }
}
