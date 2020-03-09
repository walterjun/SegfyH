using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YouSearch.Infra.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PageInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    totalResults = table.Column<int>(nullable: false),
                    resultsPerPage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SearchResponse",
                columns: table => new
                {
                    kind = table.Column<string>(nullable: true),
                    etag = table.Column<string>(nullable: true),
                    nextPageToken = table.Column<string>(nullable: true),
                    prevPageToken = table.Column<string>(nullable: true),
                    pageInfoId = table.Column<int>(nullable: true),
                    items = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchResponse_PageInfo_pageInfoId",
                        column: x => x.pageInfoId,
                        principalTable: "PageInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SearchResponse_pageInfoId",
                table: "SearchResponse",
                column: "pageInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchResponse");

            migrationBuilder.DropTable(
                name: "PageInfo");
        }
    }
}
