using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookManager.Data.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class UseImplicitNormalizationTableForBookGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookGenreAssignments");

            migrationBuilder.CreateTable(
                name: "BookGenre",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    GenreId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenre", x => new { x.BookId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_BookGenre_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookGenre_GenreId",
                table: "BookGenre",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookGenre");

            migrationBuilder.CreateTable(
                name: "BookGenreAssignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    GenreId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenreAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookGenreAssignments_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenreAssignments_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookGenreAssignments",
                columns: new[] { "Id", "BookId", "GenreId" },
                values: new object[,]
                {
                    { new Guid("0d8539bc-9ae8-402d-a24d-707dce1d7b1b"), new Guid("ec7611bb-a7cf-4af3-a81d-1cf231894dff"), new Guid("b2d0376b-3e47-461a-8ddf-e830eaf888e8") },
                    { new Guid("a425f7d4-6ec7-4eba-af20-811372cfb361"), new Guid("c5537ac1-76d6-452b-9a45-f6aca18d0e70"), new Guid("eb7f2840-b13e-4c62-ae44-b4d27ad1c251") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookGenreAssignments_BookId",
                table: "BookGenreAssignments",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenreAssignments_GenreId",
                table: "BookGenreAssignments",
                column: "GenreId");
        }
    }
}
