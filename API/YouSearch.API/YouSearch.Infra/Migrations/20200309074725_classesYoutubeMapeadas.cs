using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YouSearch.Infra.Migrations
{
    public partial class classesYoutubeMapeadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SearchResponse_PageInfo_pageInfoId",
                table: "SearchResponse");

            migrationBuilder.DropColumn(
                name: "items",
                table: "SearchResponse");

            migrationBuilder.DropColumn(
                name: "nextPageToken",
                table: "SearchResponse");

            migrationBuilder.DropColumn(
                name: "prevPageToken",
                table: "SearchResponse");

            migrationBuilder.RenameColumn(
                name: "kind",
                table: "SearchResponse",
                newName: "Kind");

            migrationBuilder.RenameColumn(
                name: "etag",
                table: "SearchResponse",
                newName: "ETag");

            migrationBuilder.RenameColumn(
                name: "pageInfoId",
                table: "SearchResponse",
                newName: "SnippetId");

            migrationBuilder.RenameIndex(
                name: "IX_SearchResponse_pageInfoId",
                table: "SearchResponse",
                newName: "IX_SearchResponse_SnippetId");

            migrationBuilder.CreateTable(
                name: "Thumbnail",
                columns: table => new
                {
                    Height = table.Column<long>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Width = table.Column<long>(nullable: true),
                    ETag = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
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

            migrationBuilder.AddForeignKey(
                name: "FK_SearchResponse_SearchResultSnippet_SnippetId",
                table: "SearchResponse",
                column: "SnippetId",
                principalTable: "SearchResultSnippet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SearchResponse_SearchResultSnippet_SnippetId",
                table: "SearchResponse");

            migrationBuilder.DropTable(
                name: "SearchResultSnippet");

            migrationBuilder.DropTable(
                name: "ThumbnailDetails");

            migrationBuilder.DropTable(
                name: "Thumbnail");

            migrationBuilder.RenameColumn(
                name: "Kind",
                table: "SearchResponse",
                newName: "kind");

            migrationBuilder.RenameColumn(
                name: "ETag",
                table: "SearchResponse",
                newName: "etag");

            migrationBuilder.RenameColumn(
                name: "SnippetId",
                table: "SearchResponse",
                newName: "pageInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_SearchResponse_SnippetId",
                table: "SearchResponse",
                newName: "IX_SearchResponse_pageInfoId");

            migrationBuilder.AddColumn<string>(
                name: "items",
                table: "SearchResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nextPageToken",
                table: "SearchResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "prevPageToken",
                table: "SearchResponse",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SearchResponse_PageInfo_pageInfoId",
                table: "SearchResponse",
                column: "pageInfoId",
                principalTable: "PageInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
