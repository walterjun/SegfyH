using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YouSearch.Infra.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PageInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    totalResults = table.Column<int>(nullable: false),
                    resultsPerPage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Thumbnail",
                columns: table => new
                {
                    Height = table.Column<long>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Width = table.Column<long>(nullable: true),
                    ETag = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thumbnail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThumbnailDetails",
                columns: table => new
                {
                    Default__Id = table.Column<int>(nullable: true),
                    HighId = table.Column<int>(nullable: true),
                    MaxresId = table.Column<int>(nullable: true),
                    MediumId = table.Column<int>(nullable: true),
                    StandardId = table.Column<int>(nullable: true),
                    ETag = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThumbnailDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThumbnailDetails_Thumbnail_Default__Id",
                        column: x => x.Default__Id,
                        principalTable: "Thumbnail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThumbnailDetails_Thumbnail_HighId",
                        column: x => x.HighId,
                        principalTable: "Thumbnail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThumbnailDetails_Thumbnail_MaxresId",
                        column: x => x.MaxresId,
                        principalTable: "Thumbnail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThumbnailDetails_Thumbnail_MediumId",
                        column: x => x.MediumId,
                        principalTable: "Thumbnail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThumbnailDetails_Thumbnail_StandardId",
                        column: x => x.StandardId,
                        principalTable: "Thumbnail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SearchResultSnippet",
                columns: table => new
                {
                    ChannelId = table.Column<string>(nullable: true),
                    ChannelTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LiveBroadcastContent = table.Column<string>(nullable: true),
                    PublishedAtRaw = table.Column<string>(nullable: true),
                    PublishedAt = table.Column<DateTime>(nullable: true),
                    ThumbnailsId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    ETag = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchResultSnippet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchResultSnippet_ThumbnailDetails_ThumbnailsId",
                        column: x => x.ThumbnailsId,
                        principalTable: "ThumbnailDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SearchResponse",
                columns: table => new
                {
                    Kind = table.Column<string>(nullable: true),
                    ETag = table.Column<string>(nullable: true),
                    SnippetId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchResponse_SearchResultSnippet_SnippetId",
                        column: x => x.SnippetId,
                        principalTable: "SearchResultSnippet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SearchResponse_SnippetId",
                table: "SearchResponse",
                column: "SnippetId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchResultSnippet_ThumbnailsId",
                table: "SearchResultSnippet",
                column: "ThumbnailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ThumbnailDetails_Default__Id",
                table: "ThumbnailDetails",
                column: "Default__Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThumbnailDetails_HighId",
                table: "ThumbnailDetails",
                column: "HighId");

            migrationBuilder.CreateIndex(
                name: "IX_ThumbnailDetails_MaxresId",
                table: "ThumbnailDetails",
                column: "MaxresId");

            migrationBuilder.CreateIndex(
                name: "IX_ThumbnailDetails_MediumId",
                table: "ThumbnailDetails",
                column: "MediumId");

            migrationBuilder.CreateIndex(
                name: "IX_ThumbnailDetails_StandardId",
                table: "ThumbnailDetails",
                column: "StandardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageInfo");

            migrationBuilder.DropTable(
                name: "SearchResponse");

            migrationBuilder.DropTable(
                name: "SearchResultSnippet");

            migrationBuilder.DropTable(
                name: "ThumbnailDetails");

            migrationBuilder.DropTable(
                name: "Thumbnail");
        }
    }
}
